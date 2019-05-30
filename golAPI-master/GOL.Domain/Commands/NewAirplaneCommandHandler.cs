using GOL.Commom.Notification;
using GOL.Commom.Publisher;
using GOL.Domain.DTO;
using GOL.Domain.Entities.Airplane;
using GOL.Domain.Events;
using GOL.Domain.Interfaces;
using GOL.Domain.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GOL.Domain.Commands
{
    public class NewAirplaneCommandHandler
    {
        private readonly IAirplaneRepository _airplaneRepository;        
        private readonly DomainNotificationHandler _domainNotificationHandler;
        public NewAirplaneCommandHandler(IAirplaneRepository airplaneRepository,  DomainNotificationHandler domainNotificationHandler)
        {
            _airplaneRepository = airplaneRepository;            
            _domainNotificationHandler = domainNotificationHandler;
        }

        public Task<Unit> Handle(NewAirplaneCommand command)
        {
            if (!command.IsValid())
            {
                command.ValidationResult.Errors.ToList().ForEach(error => _domainNotificationHandler.Handle(new DomainNotification(command.GetType().ToString(), error.ErrorMessage)));
                return Unit.Task;
            }

            Airplane airplane = new Airplane(command.Airplane.CodigoAviao, command.Airplane.Modelo, command.Airplane.QtdPassageiros);

            command.Airplane.id = _airplaneRepository.Add(airplane);
            //_publisher.RaiseEvent(new NewAirplaneEvent(airplane));

            return Unit.Task;
        }
    }
}
