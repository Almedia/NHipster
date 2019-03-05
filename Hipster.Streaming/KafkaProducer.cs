using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Hipster.Domain;

namespace Hipster.Streaming
{
    public class KafkaProducer:IMessageProducer
    {
        public void Produce(string topic,string message){
            //Kafka produce işlemini bu adımda yapıyoruz;
            var config = new Dictionary<string, object>
            {
                { "bootstrap.servers", "localhost:9092" }
            };
            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                producer.ProduceAsync(topic, null, message);
                producer.Flush(100);
            }
        }   
    }
}