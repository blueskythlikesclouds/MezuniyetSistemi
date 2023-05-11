using MezuniyetSistemi.Entities.Concrete;

namespace MezuniyetSistemi.Business.Abstract;

public interface ICompanyService
{
    IList<Company> FindAll(bool trackChanges);
    Company FindById(int id, bool trackChanges);
    void Add(Company company);
    void Update(int id, Company company, bool trackChanges);
    void Delete(int id);
}