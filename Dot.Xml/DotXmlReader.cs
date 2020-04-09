namespace System.Xml
{
    public class DotXmlReader : XmlWrappingReader
    {
        private readonly XmlSerializeOptions _options;
        private readonly string _dateTimeFormat;

        public DotXmlReader(XmlReader baseReader, XmlSerializeOptions options, XmlRootExAttribute attr)
            : base(baseReader)
        {
            _options = options;
            _dateTimeFormat = attr?.DateTimeFormat ?? options.DateTimeFormat;
        }

        public override string ReadElementContentAsString()
        {
            var content = base.ReadElementContentAsString();
            if (!string.IsNullOrEmpty(_dateTimeFormat) && DateTime.TryParseExact(content, _options.DateTimeFormat, null, Globalization.DateTimeStyles.None, out DateTime dateTime))
                content = dateTime.ToString("o"); // ISO 8601 -> yyyy-MM-ddTHH:mm:ss.fffffffzzzzzz

            return content;
        }
    }
}