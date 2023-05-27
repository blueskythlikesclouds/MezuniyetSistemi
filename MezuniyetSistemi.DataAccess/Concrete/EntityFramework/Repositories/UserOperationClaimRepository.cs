using Core.DataAccess.Concrete;
using Core.Entities.Concrete;
using MezuniyetSistemi.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Repositories
{
    public class UserOperationClaimRepository : RepositoryBase<UserOperationClaim>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(DbContext context) : base(context)
        {
        }
    }
}
