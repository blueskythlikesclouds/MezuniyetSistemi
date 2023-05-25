using Core.Entities.Concrete;
using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUnitOfWork UnitOfWork { get; }

        public UserManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Add(User user)
        {
            UnitOfWork.Users.Add(user);
            UnitOfWork.Save();
        }

        public User GetByMail(string email)
        {
            var user = UnitOfWork.Users.FindByCondition(x => x.Email == email,false).FirstOrDefault();
            return user;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return UnitOfWork.Users.GetClaims(user);
        }

        public void AddUser(User user, UserRoles role)
        {
            UnitOfWork.Users.Add(user);
            UnitOfWork.UserOperationClaims.Add(new()
            {
                UserId = user.Id,
                OperationClaimId = (int)UserRoles.User
            });
            UnitOfWork.Save();
        }
    }
}
