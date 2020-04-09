using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Dot.Xml.Sample.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dot.Xml.Sample
{
    public class SampleService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            SerializeByXmlSerializeOptionsSample();
            SerializeByXmlRootExSample();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void SerializeByXmlSerializeOptionsSample()
        {
            var player = new Player
            {
                Id = 1,
                Name = "gaolin",
                Weight = 176.6M
            };

            var playerXml = XmlConverter.Serialize(player);
            Console.WriteLine(playerXml);

            var playerCopy = XmlConverter.Deserialize<Player>(playerXml);
            Console.WriteLine(playerCopy);
        }

        public void SerializeByXmlRootExSample()
        {
            var member = new Member
            {
                Id = 1,
                Name = "gaolin",
                Weight = 176.6M
            };

            var memberXml = XmlConverter.Serialize(member);
            Console.WriteLine(memberXml);

            var memberCopy = XmlConverter.Deserialize<Member>(memberXml);
            Console.WriteLine(memberCopy);
        }

        static async Task Main(string[] args)
        {
            await new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddXmlSerializer(x =>
                    {
                        x.XmlWriterSettings.Encoding = Encoding.UTF8;
                        x.FullEnding = true;
                        x.UseCDATA = true;
                        x.RemoveNamespace = true;
                        x.RemoveXmlDeclaration = true;
                        x.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                    });

                    services.AddHostedService<SampleService>();
                })
                .RunConsoleAsync();
        }
    }
}