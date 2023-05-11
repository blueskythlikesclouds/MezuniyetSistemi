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
        private UserProfileRepository _profileRepository;
        private EMailRepository _eMailRepository;
        public UnitOfWork(MezuniyetSistemiContext context)
        {
            _context = context;
        }

        public IUserProfileRepository Profiles => _profileRepository ?? new UserProfileRepository(_context); 
        public IEMailRepository Emails => _eMailRepository ?? new EMailRepository(_context);

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
