using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.DataAccess.Abstract
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
