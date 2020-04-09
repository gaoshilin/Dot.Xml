# Dot.Xml

1. Install-Package Dot.Xml

2. 全局配置
   ```C#
   services.AddXmlSerializer(x =>
            {
                x.XmlWriterSettings.Encoding = Encoding.UTF8;
                x.FullEnding = true;
                x.UseCDATA = true;
                x.RemoveNamespace = true;
                x.RemoveXmlDeclaration = true;
                x.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            });
   ```

3. 自定义配置，优先级高于全局配置
   ```C#
   [XmlRootEx(FullEnding = false, UseCDATA = false, RemoveNamespace = false, RemoveXmlDeclaration = false, DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffffffzzzzzz")]
   public class Member {}
   ```
