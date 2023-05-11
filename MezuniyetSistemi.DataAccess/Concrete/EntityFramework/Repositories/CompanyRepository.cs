using Core.DataAccess.Concrete;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Repositories;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    public CompanyRepository(DbContext context) : base(context)
    {
    }
}