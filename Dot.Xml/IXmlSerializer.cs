namespace System.Xml.Serialization
{
    public interface IXmlSerializer
    {
        string Serialize(object o);
        object Deserialize(Type type, string xml);
        T Deserialize<T>(string xml);
    }
}