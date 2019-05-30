using GOL.Commom.Pagging;
using GOL.Database.Context;
using GOL.Domain.Entities.Airplane;
using GOL.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GOL.Database.Repositories
{
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly GolContext _context;
        public AirplaneRepository(GolContext context)
        {
            _context = context;
        }
        public Guid Add(Airplane airplane)
        {
            _context.Airplanes.Add(airplane);
            return airplane.Id;
        }

        public void Delete(Guid id)
        {
            var airplane = _context.Airplanes.Where(w => w.Id == id).FirstOrDefault();
            _context.Airplanes.Remove(airplane);
        }

        public Airplane Get(Guid id)
        {
            return _context.Airplanes.Where(w => w.Id == id).FirstOrDefault();
        }

        public PagedResult<Airplane> Get(int actualPage, int pageSize)
        {
            return _context.Airplanes.GetPaged(actualPage, pageSize);
        }


        public void Update(Airplane airplane)
        {
            _context.Airplanes.Update(airplane);            
        }
    }
}
