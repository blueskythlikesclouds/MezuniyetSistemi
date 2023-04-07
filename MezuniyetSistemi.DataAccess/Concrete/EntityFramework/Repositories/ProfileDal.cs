using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Contexts;
using MezuniyetSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Repositories
{
    public class ProfileDal : RepositoryBase<Profile, MezuniyetSistemiContext>, IProfileDal
    {
        public ProfileDal(MezuniyetSistemiContext context) : base(context)
        {
        }
    }
}
