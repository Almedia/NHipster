using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Hipster.ApplicationService.Service;
using Hipster.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Hipster.Streaming
{
    public class MessageConsumer : IMessageConsumer
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        //private readonly   IMemberService _memberService;
        public MessageConsumer(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory=serviceScopeFactory;
        }

        public void RegisterConsumer()
        {
            var config = new Dictionary<string, object>
            {
                { "group.id", "messageConsumer" },
                { "bootstrap.servers", "localhost:9092" },
                { "enable.auto.commit", "false"}
            };

            using (var consumer = new Consumer<Null, string>(config, null, new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Subscribe(new string[] { "member-event", "order" });
                //consumer.OnError += (_, e) => keepConsuming = !e.IsFatal;
                consumer.OnMessage += (_, msg) =>
                {
                    try
                    {
                        // if (msg.Topic == "member-event")
                        // {
                        //     var memberId = Guid.Parse(msg.Value);

                        //     using (var scope = _serviceScopeFactory.CreateScope())
                        //     {
                        //         var context = scope.ServiceProvider.GetService<HipsterContext>();
                        //         var applicationService=scope.ServiceProvider.GetService<IMemberService>();
                        //         applicationService.ActivateMember(memberId);
                        //     }
                           
                        // }
                        Console.WriteLine($"Message: {msg.Topic} Partition: {msg.Partition} Offset: {msg.Offset} {msg.Value}");
                        //Business Logic 
                    }
                    catch (Exception ex)
                    {

                    }
                    //application Service üzerinden domain etkileşimini sağlayabiliriz
                    //msg.Topic bazında command aksiyonları almamız gerekiyor

                    //
                    consumer.CommitAsync(msg);
                };

                while (true)
                {
                    consumer.Poll(100);
                }
            }
        }

    }
}