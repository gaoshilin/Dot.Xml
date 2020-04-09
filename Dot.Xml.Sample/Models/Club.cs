using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Dot.Xml.Sample.Models
{
    public class Club
    {
        public string Name { get; set; } = string.Empty;

        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}