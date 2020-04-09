# Dot.Xml

1. Install-Package Dot.Xml

2.```C#
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

3.```C#
  [XmlRootEx(UseCDATA = false, FullEnding = false, RemoveXmlDeclaration = false, RemoveNamespace = false, DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffffffzzzzzz")]
    public class Member {}
  ```
