using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete;
using Core.Entities.Concrete;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Contexts;
using MezuniyetSistemi.Entities.Concrete;
using MezuniyetSistemi.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.DataAccess.Concrete.EntityFramework.Repositories
{
    public class UserProfileRepository : RepositoryBase<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(MezuniyetSistemiContext context) : base(context)
        {
        }

        public PagedList<UserProfile> GetAllWithPagination(UserProfileParameters userProfileParameters, bool trackChanges)
        {
            var books = FindAll(trackChanges).ToList();

            return PagedList<UserProfile>
                .ToPagedList(books, userProfileParameters.CurrentPage, userProfileParameters.PageSize);
        }

    }
}
