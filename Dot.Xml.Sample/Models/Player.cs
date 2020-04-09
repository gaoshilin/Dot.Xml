using System.Xml.Serialization;

namespace Dot.Xml.Sample.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public Club Club { get; set; } = new Club();

        public override string ToString() => XmlConverter.Serialize(this);
    }
}