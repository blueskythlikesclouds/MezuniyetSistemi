using Core.Entities.Concrete;
using MezuniyetSistemi.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        void AddUser(User user, UserRoles role);
        User GetByMail(string email);
    }
}
