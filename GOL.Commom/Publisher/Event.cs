using MediatR;

namespace GOL.Commom.Publisher
{
    public abstract class Event : Message, INotification
    {
    }
}
