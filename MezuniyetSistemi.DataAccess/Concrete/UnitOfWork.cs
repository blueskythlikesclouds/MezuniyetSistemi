using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Contexts;
using MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MezuniyetSistemiContext _context;
        private ProfileRepository _profileRepository;
        public UnitOfWork(MezuniyetSistemiContext context)
        {
            _context = context;
        }

        public IProfileRepository Profiles => _profileRepository ?? new ProfileRepository(_context); 

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
