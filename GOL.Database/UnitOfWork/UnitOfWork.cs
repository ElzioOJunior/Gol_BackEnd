using GOL.Database.Context;
using GOL.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GOL.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GolContext _context;

        public UnitOfWork(GolContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
