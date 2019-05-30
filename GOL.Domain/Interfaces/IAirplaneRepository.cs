using GOL.Commom.Pagging;
using GOL.Domain.Entities.Airplane;
using System;
using System.Collections.Generic;
using System.Text;

namespace GOL.Domain.Interfaces
{
    public interface IAirplaneRepository
    {
        Guid Add(Airplane airplane);
        void Update(Airplane airplane);
        void Delete(Guid id);
        Airplane Get(Guid id);
        PagedResult<Airplane> Get(int actualPage, int pageSize);
    }
}
