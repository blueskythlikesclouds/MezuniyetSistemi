namespace MezuniyetSistemi.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IUserProfileRepository Profiles { get; }
        IEMailRepository Emails { get; }
        ISpecialtyRepository Specialties { get; }
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }

        int Save();
    }
}
