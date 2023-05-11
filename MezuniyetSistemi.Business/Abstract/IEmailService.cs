using MezuniyetSistemi.Entities.Concrete;

namespace MezuniyetSistemi.Business.Abstract
{
    public interface IEmailService
    {
        IList<Email> FindAll(bool trackChanges);
        Email FindById(int id, bool trackChanges);
        void Add(Email email);
        void Update(int id, Email email, bool trackChanges);
        void Delete(Email email);
    }
}
