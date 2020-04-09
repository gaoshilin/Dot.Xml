using System;
using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DotXmlExtensions
    {
        public static IServiceCollection AddXmlSerializer(this IServiceCollection services, Action<XmlSerializeOptions> configure)
             => XmlConverter.Configure(services, configure);
    }
}