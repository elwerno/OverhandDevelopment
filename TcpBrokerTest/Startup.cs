using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet;
using MQTTnet.AspNetCore;
using MQTTnet.Server;

namespace TcpBrokerTest
{
    public class Startup
    {
        // In class _Startup_ of the ASP.NET Core 2.0 project.
        public void ConfigureServices(IServiceCollection services)
        {
            //this adds a hosted mqtt server to the services
            var ipAddress = new byte[] {0, 0, 0, 0};
            var ipObject = new System.Net.IPAddress(ipAddress);
            services.AddHostedMqttServer(builder => builder.WithDefaultEndpointBoundIPAddress(ipObject).WithDefaultEndpointPort(1883));

            //this adds tcp server support based on System.Net.Socket
            services.AddMqttTcpServerAdapter();

            //this adds websocket support
            services.AddMqttWebSocketServerAdapter();
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // this maps the websocket to an mqtt endpoint
            app.UseMqttEndpoint();
            // other stuff
            
            var server = app.ApplicationServices.GetService<IMqttServer>();
            server.ApplicationMessageReceived += (s, e) =>
            {
                Console.WriteLine("Hello World");
                // TODO split values up! & find out what is what.
                // -> parse values like in the code from Ricky.
                var payload = string.Concat(e.ApplicationMessage.Payload);
                Console.WriteLine(
                    $"'{e.ClientId}' reported '{e.ApplicationMessage.Topic}' > '{payload}'",
                    ConsoleColor.Magenta);
            };

           // Console.WriteLine(server.Options.DefaultEndpointOptions.BoundInterNetworkAddress);

        }

    }
}