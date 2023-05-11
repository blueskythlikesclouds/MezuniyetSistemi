using Core.DataAccess.Concrete;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EMailRepository : RepositoryBase<Email>, IEMailRepository
    {
        public EMailRepository(DbContext context) : base(context)
        {

        }
    }
}
