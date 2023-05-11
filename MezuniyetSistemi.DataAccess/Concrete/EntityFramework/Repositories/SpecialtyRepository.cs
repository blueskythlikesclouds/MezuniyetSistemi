using Core.DataAccess.Concrete;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Repositories
{
    public class SpecialtyRepository : RepositoryBase<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(DbContext context) : base(context)
        {
        }
    }
}
