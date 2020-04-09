namespace System.Xml
{
    public class DotXmlWriter : XmlWrappingWriter
    {
        private readonly XmlSerializeOptions _options;
        private readonly XmlRootExAttribute _attr;

        public bool FullEnding => _attr?.FullEnding ?? _options.FullEnding;
        public bool UseCDATA => _attr?.UseCDATA ?? _options.UseCDATA;
        public bool RemoveXmlDeclaration => _attr?.RemoveXmlDeclaration ?? _options.RemoveXmlDeclaration;
        public bool RemoveNamespace => _attr?.RemoveNamespace ?? _options.RemoveNamespace;
        public string DateTimeFormat => _attr?.DateTimeFormat ?? _options.DateTimeFormat;

        public DotXmlWriter(XmlWriter baseWriter, XmlSerializeOptions options, XmlRootExAttribute attr = null)
            : base(baseWriter)
        {
            _options = options;
            _attr = attr;
        }

        public override void WriteEndElement()
        {
            if (FullEnding)
                base.WriteFullEndElement();
            else
                base.WriteEndElement();
        }

        public override void WriteString(string text)
        {
            if (UseCDATA)
                base.WriteCData(text);
            else
                base.WriteString(text);
        }

        /// <summary>
        /// 重写此方法实现日期格式的自定义
        /// </summary>
        public override void WriteRaw(string data)
        {
            if (double.TryParse(data, out double d)) // 将浮点数排除，否则可能出现值 1.1 被转为化 2020-01-01 的情况
                base.WriteRaw(data);
            else if (DateTime.TryParse(data, out DateTime dateTime))
                base.WriteRaw(dateTime.ToString(DateTimeFormat));
            else
                base.WriteRaw(data);
        }
    }
}