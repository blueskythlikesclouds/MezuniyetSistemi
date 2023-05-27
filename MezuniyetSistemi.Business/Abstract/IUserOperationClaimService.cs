using Core.Entities.Concrete;
using MezuniyetSistemi.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        void Add(int userId, UserRoles role);
    }
}
