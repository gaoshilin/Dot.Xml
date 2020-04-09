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
   基于上述全局配置的输出样例：
   ```XML
   <Player>
       <Id>1</Id>
       <Name><![CDATA[gaolin]]></Name>
       <Weight>176.6</Weight>
       <Club>
           <Name></Name>
           <CreateTime>2020-04-09 14:23:49</CreateTime>
       </Club>
   </Player>
   ```

3. 自定义配置，优先级高于全局配置
   ```C#
   [XmlRootEx(FullEnding = false, UseCDATA = false, RemoveNamespace = false, RemoveXmlDeclaration = false, DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffffffzzzzzz")]
   public class Member { *** }
   ```
   自定义配置取代全局配置后输出样例：
   ```XML
   <?xml version="1.0" encoding="utf-8"?> <!-- 保留了XML声明 -->
   <Member
       xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
       xmlns:xsd="http://www.w3.org/2001/XMLSchema"> <!-- 保留了名称空间 -->
       <Id>1</Id>
       <Name>gaolin</Name> <!--无CDATA-->
       <Weight>176.6</Weight>
       <Club>
           <Name /> <!--关闭FullEnding-->
           <CreateTime>2020-04-09T14:32:30.1053125+08:00</CreateTime>
       </Club>
   </Member>
   ```

4. 静态调用
   ```C#
   XmlConverter.Serialize(player);
   XmlConverter.Deserialize<Player>(playerXml);
   ```
   
5. 依赖注入方式调用，注入：
   ```C#
   public SampleService(DotXmlSerializer serializer) => _serializer = serializer;
   ```
   调用：
   ```C#
   _serializer.Serialize(player);
   ```
