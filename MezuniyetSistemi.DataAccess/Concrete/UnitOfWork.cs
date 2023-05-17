using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Contexts;
using MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Repositories;

namespace MezuniyetSistemi.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MezuniyetSistemiContext _context;
        private UserProfileRepository _profileRepository;
        private EMailRepository _eMailRepository;
        private SpecialtyRepository _specialtyRepository;
        private CompanyRepository _companyRepository;
        private UserRepository _userRepository;

        public UnitOfWork(MezuniyetSistemiContext context)
        {
            _context = context;
        }

        public IUserProfileRepository Profiles => _profileRepository ?? new UserProfileRepository(_context);
        public IEMailRepository Emails => _eMailRepository ?? new EMailRepository(_context);
        public ISpecialtyRepository Specialties => _specialtyRepository ?? new SpecialtyRepository(_context);
        public ICompanyRepository Companies => _companyRepository ?? new CompanyRepository(_context);

        public IUserRepository Users => _userRepository ?? new UserRepository(_context);

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
