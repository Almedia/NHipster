namespace Hipster.EventBus
{
    public interface IHandler<T>
    {
         void Handle(T t);
    }
}