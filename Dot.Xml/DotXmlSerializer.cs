using System.IO;
using System.Reflection;

namespace System.Xml.Serialization
{
    public class DotXmlSerializer : IXmlSerializer
    {
        private readonly XmlSerializeOptions _options;

        public DotXmlSerializer(XmlSerializeOptions options) => _options = options;

        public object Deserialize(Type type, string xml)
        {
            using var reader = new StringReader(xml);
            var serializer = new XmlSerializer(type);
            return serializer.Deserialize(reader);
        }

        public T Deserialize<T>(string xml)
        {
            //using var reader = new StringReader(xml);
            //var serializer = new XmlSerializer(typeof(T));
            //return (T)serializer.Deserialize(reader);

            var attribute = typeof(T).GetCustomAttribute<XmlRootExAttribute>();

            using var stringReader = new StringReader(xml);
            using var baseReader = XmlReader.Create(stringReader);
            using var reader = new DotXmlReader(baseReader, _options, attribute);

            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(reader);
        }

        public string Serialize(object o)
        {
            var attribute = o.GetType().GetCustomAttribute<XmlRootExAttribute>();

            var writerSettings = _options.XmlWriterSettings.Clone();
            writerSettings.OmitXmlDeclaration = attribute?.RemoveXmlDeclaration ?? _options.RemoveXmlDeclaration;

            using var stream = new MemoryStream();
            using var baseWriter = XmlWriter.Create(stream, writerSettings);
            using var writer = new DotXmlWriter(baseWriter, _options, attribute);

            var serializer = new XmlSerializer(o.GetType());
            var removeNamespace = attribute?.RemoveNamespace ?? _options.RemoveNamespace;
            if (removeNamespace)
            {
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "");
                serializer.Serialize(writer, o, namespaces);
            }
            else
            {
                serializer.Serialize(writer, o);
            }

            stream.Position = 0;
            var reader = new StreamReader(stream, _options.XmlWriterSettings.Encoding);
            return reader.ReadToEnd();
        }
    }
}