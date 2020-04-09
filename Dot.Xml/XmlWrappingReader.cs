using System.Xml.Schema;

namespace System.Xml
{
    public class XmlWrappingReader : XmlReader, IXmlLineInfo
    {
        protected XmlReader _reader;
        protected IXmlLineInfo _readerAsIXmlLineInfo;

        public XmlWrappingReader(XmlReader baseReader) => _reader = baseReader;

        public override void Close() => _reader.Close();

        protected override void Dispose(bool disposing) => (_reader as IDisposable).Dispose();

        public override string GetAttribute(int i) => _reader.GetAttribute(i);

        public override string GetAttribute(string name) => _reader.GetAttribute(name);

        public override string GetAttribute(string name, string namespaceURI) => _reader.GetAttribute(name, namespaceURI);

        public virtual bool HasLineInfo() => _readerAsIXmlLineInfo?.HasLineInfo() ?? false;

        public override string LookupNamespace(string prefix) => _reader.LookupNamespace(prefix);

        public override void MoveToAttribute(int i) => _reader.MoveToAttribute(i);

        public override bool MoveToAttribute(string name) => _reader.MoveToAttribute(name);

        public override bool MoveToAttribute(string name, string ns) => _reader.MoveToAttribute(name, ns);

        public override bool MoveToElement() => _reader.MoveToElement();

        public override bool MoveToFirstAttribute() => _reader.MoveToFirstAttribute();

        public override bool MoveToNextAttribute() => _reader.MoveToNextAttribute();

        public override bool Read() => _reader.Read();

        public override bool ReadAttributeValue() => _reader.ReadAttributeValue();

        public override void ResolveEntity() => _reader.ResolveEntity();

        public override void Skip() => _reader.Skip();

        public override int AttributeCount => _reader.AttributeCount;

        public override string BaseURI => _reader.BaseURI;

        public override bool CanResolveEntity => _reader.CanResolveEntity;

        public override int Depth => _reader.Depth;

        public override bool EOF => _reader.EOF;

        public override bool HasAttributes => _reader.HasAttributes;

        public override bool HasValue => _reader.HasValue;

        public override bool IsDefault => _reader.IsDefault;

        public override bool IsEmptyElement => _reader.IsEmptyElement;

        public virtual int LineNumber => _readerAsIXmlLineInfo?.LineNumber ?? 0;

        public virtual int LinePosition => _readerAsIXmlLineInfo?.LinePosition ?? 0;

        public override string LocalName => _reader.LocalName;

        public override string Name => _reader.Name;

        public override string NamespaceURI => _reader.NamespaceURI;

        public override XmlNameTable NameTable => _reader.NameTable;

        public override XmlNodeType NodeType => _reader.NodeType;

        public override string Prefix => _reader.Prefix;

        public override char QuoteChar => _reader.QuoteChar;

        protected XmlReader Reader
        {
            get
            {
                return _reader;
            }
            set
            {
                _reader = value;
                _readerAsIXmlLineInfo = value as IXmlLineInfo;
            }
        }

        public override ReadState ReadState => _reader.ReadState;

        public override IXmlSchemaInfo SchemaInfo => _reader.SchemaInfo;

        public override XmlReaderSettings Settings => _reader.Settings;

        public override string Value => _reader.Value;

        public override Type ValueType => _reader.ValueType;

        public override string XmlLang => _reader.XmlLang;

        public override XmlSpace XmlSpace => _reader.XmlSpace;
    }
}