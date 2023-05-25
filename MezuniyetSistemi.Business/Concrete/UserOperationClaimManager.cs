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
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private IUnitOfWork _unitOfWork { get; }

        public UserOperationClaimManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(int userId, UserRoles role)
        {
            UserOperationClaim claim = new UserOperationClaim
            {
                UserId = userId,
                OperationClaimId = (int)role
            };
            _unitOfWork.UserOperationClaims.Add(claim);
            _unitOfWork.Save();
        }
    }
}
