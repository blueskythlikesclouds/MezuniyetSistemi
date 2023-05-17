using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.Entities.Concrete;

namespace MezuniyetSistemi.Business.Concrete;

public class CompanyManager : ICompanyService
{
    private IUnitOfWork _unitOfWork { get; }

    public CompanyManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Add(Company company)
    {
        _unitOfWork.Companies.Add(company);
        _unitOfWork.Save();
    }

    public void Delete(int id)
    {
        var company = _unitOfWork.Companies.FindByCondition(x => x.Id == id, false).FirstOrDefault();
        if (company != null)
        {
            _unitOfWork.Companies.Delete(company);
            _unitOfWork.Save();
        }
    }

    public IList<Company> FindAll(bool trackChanges)
    {
        return _unitOfWork.Companies.FindAll(trackChanges).ToList();
    }

    public Company FindById(int id, bool trackChanges)
    {
        return _unitOfWork.Companies.FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();
    }

    public void Update(int id, Company company, bool trackChanges)
    {
        _unitOfWork.Companies.Update(company);
        _unitOfWork.Save();
    }
}