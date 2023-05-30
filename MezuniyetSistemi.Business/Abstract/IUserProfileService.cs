using Core.Entities.Concrete;
using MezuniyetSistemi.Entities.Concrete;
using MezuniyetSistemi.Entities.DTOs;
using MezuniyetSistemi.Entities.RequestFeatures;

namespace MezuniyetSistemi.Business.Abstract
{
    public interface IUserProfileService
    {
        IList<UserProfile> FindAll(bool trackChanges);
        PagedList<UserProfile> FindAllWithPagination(UserProfileParameters parameters, bool trackChanges);
        UserProfile FindById(int id, bool trackChanges);
        UserProfile FindByIdWithAllProp(int id, bool trackChanges);
        void Add(UserProfileDtoForAdd profileDto);
        void Update(int id, UserProfileDtoForUpdate profileDto, bool trackChanges);
        void Delete(UserProfile profile);
        UserProfile GetByUserId(int userId, bool trackChanges);
    }

}
