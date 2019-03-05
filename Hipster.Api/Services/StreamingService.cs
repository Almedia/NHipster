using System;
using System.Threading;
using System.Threading.Tasks;
using Hipster.Streaming;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Hipster.Api.Services
{
    public class StreamingService : IHostedService, IDisposable
    {
        private readonly IMessageConsumer _messageConsumer;
        private readonly ILogger _logger;

        public StreamingService(ILoggerFactory loggerFactory,IMessageConsumer messageConsumer){
            _logger=loggerFactory.CreateLogger<StreamingService>();
            _messageConsumer=messageConsumer;
        }

        public void Dispose()
        {
            
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //KafkaConsumer ayaga kalkabilir
            _logger.LogInformation("BackGround Service Started");
            _messageConsumer.RegisterConsumer();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}