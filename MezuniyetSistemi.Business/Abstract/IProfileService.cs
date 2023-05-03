using MezuniyetSistemi.Entities.Concrete;
using MezuniyetSistemi.Entities.DTOs;
using MezuniyetSistemi.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Business.Abstract
{
    public interface IProfileService
    {
        IList<UserProfile> FindAll(bool trackChanges);
        IList<UserProfile> FindAllWithPagination(UserProfileParameters parameters, bool trackChanges);
        UserProfile FindById(int id, bool trackChanges);
        void Add(UserProfileDtoForAdd profileDto);
        void Update(int id,UserProfileDtoForUpdate profileDto, bool trackChanges);
        void Delete(UserProfile profile);
    }
}
