using GOL.Commom.Notification;
using GOL.Commom.Pagging;
using GOL.Commom.Publisher;
using GOL.Domain.Commands;
using GOL.Domain.DTO;
using GOL.Domain.Entities.Airplane;
using GOL.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GOL.Service.Controllers
{
    [Route("api/v1/airplanes")]
    [ApiController]
    public class AirplaneController : APIController
    {
        private readonly IAirplaneRepository _airplaneRepository;        
        private readonly NewAirplaneCommandHandler _handler;
        private readonly UpdateAirplaneCommandHandler _updatehandler;
        public AirplaneController(
            IAirplaneRepository airplaneRepository,            
            IUnitOfWork unitOfWork,
            NewAirplaneCommandHandler handler,
            UpdateAirplaneCommandHandler updateHandler,
            DomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler, unitOfWork)
        {
            _airplaneRepository = airplaneRepository;            
            _handler = handler;
            _updatehandler = updateHandler;
        }

        /// <summary>
        /// Retorna uma lista de airplanes
        /// </summary>
        /// <param name="actualPage">pagina atual</param>
        /// <param name="pageSize">itens por página</param>
        /// <returns>Lista paginada de airplanes</returns>
        [HttpDelete("{id}")]        
        public IActionResult Delete(Guid id)
        {
            _airplaneRepository.Delete(id);
            return Response();
        }

        [HttpPut()]
        public IActionResult Put(AirplaneDTO airplane)
        {
            var newAirplaneCommand = new NewAirplaneCommand(airplane);
            _updatehandler.Handle(newAirplaneCommand);
            return Response(newAirplaneCommand);
        }

        [HttpGet()]
        public ActionResult<PagedResult<Airplane>> Get(int actualPage = 1, int pageSize = 20)
        {
            return Ok(_airplaneRepository.Get(actualPage, pageSize));
        }

        [HttpPost()]        
        public IActionResult Post(AirplaneDTO airplane)
        {
            var newAirplaneCommand = new NewAirplaneCommand(airplane);
            _handler.Handle(newAirplaneCommand);
            return Response(newAirplaneCommand);
        }
    }
}
