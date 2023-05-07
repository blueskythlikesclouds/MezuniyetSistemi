using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using MezuniyetSistemi.Entities.Concrete;
using MezuniyetSistemi.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.DataAccess.Abstract
{
    public interface IProfileRepository : IRepositoryBase<UserProfile>
    {
        PagedList<UserProfile> GetAllWithPagination(UserProfileParameters userProfileParameters, bool trackChanges);
    }
}
