using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Mvc.Formatters
{
    public class DotXmlSerializerOutputFormatter : XmlSerializerOutputFormatter
    {
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
            => await context.HttpContext.Response.WriteAsync(XmlConverter.Serialize(context.Object));
    }
}