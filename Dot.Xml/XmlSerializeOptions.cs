namespace System.Xml
{
    public class XmlSerializeOptions
    {
        public XmlWriterSettings XmlWriterSettings { get; set; } = new XmlWriterSettings();

        /// <summary>
        /// 遇到空字符串时是否输出全节点，如：<NodeName></NodeName>
        /// </summary>
        public bool FullEnding { get; set; } = true;

        /// <summary>
        /// 是否使用<![CDATA[]]>包裹字符串
        /// </summary>
        public bool UseCDATA { get; set; } = true;

        /// <summary>
        /// 是否移除 XML 声明节点：<?xml version="1.0" encoding="utf-8" ?>
        /// </summary>
        public bool RemoveXmlDeclaration { get; set; } = true;

        /// <summary>
        /// 是否移除根节点的名称空间
        /// </summary>
        public bool RemoveNamespace { get; set; } = true;

        /// <summary>
        /// 日期格式
        /// </summary>
        public string DateTimeFormat { get; set; }
    }
}