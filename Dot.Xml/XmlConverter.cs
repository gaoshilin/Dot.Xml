using Microsoft.Extensions.DependencyInjection;

namespace System.Xml.Serialization
{
    public static class XmlConverter
    {
        public static XmlSerializeOptions Options { get; private set; } = new XmlSerializeOptions();
        public static DotXmlSerializer Serializer { get; private set; }

        public static string Serialize(object o) => Serializer.Serialize(o);

        public static T Deserialize<T>(string xml) => Serializer.Deserialize<T>(xml);

        public static IServiceCollection Configure(IServiceCollection services, Action<XmlSerializeOptions> configure)
        {
            // 初始到静态实例中，以支持静态调用方式
            configure(Options);
            Serializer = new DotXmlSerializer(Options);

            // 注入到容器中，以支持依赖注入的使用方式
            return services.AddSingleton(Options)
                           .AddSingleton(Serializer);
        }
    }
}