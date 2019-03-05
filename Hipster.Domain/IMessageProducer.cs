namespace Hipster.Domain
{
    public interface IMessageProducer
    {
      void Produce(string topic,string message);    
    }
}