using System;
using System.Collections.Generic;
using System.Text;

namespace GOL.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
