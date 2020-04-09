using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Dot.Xml.Sample.Models
{
    [XmlRootEx(UseCDATA = false, FullEnding = false, RemoveXmlDeclaration = false, RemoveNamespace = false, DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffffffzzzzzz")]
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public Club Club { get; set; } = new Club();

        public override string ToString() => XmlConverter.Serialize(this);
    }
}