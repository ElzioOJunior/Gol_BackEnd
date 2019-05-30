using GOL.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GOL.Domain.Events
{
    public class NewAirplaneEventHandler : INotificationHandler<NewAirplaneEvent>
    {
        private readonly IAirplaneRepository _airplaneRepository;
        public NewAirplaneEventHandler(IAirplaneRepository airplaneRepository)
        {
            _airplaneRepository = airplaneRepository;
        }
        Task INotificationHandler<NewAirplaneEvent>.Handle(NewAirplaneEvent newAirplaneEvent, CancellationToken cancellationToken)
        {
            _airplaneRepository.Add(newAirplaneEvent.Airplane);

            return Unit.Task;
        }
    }
}
