using AutoMapper;
using Core.Entities.Concrete;
using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.Entities.Concrete;
using MezuniyetSistemi.Entities.DTOs;
using MezuniyetSistemi.Entities.RequestFeatures;

namespace MezuniyetSistemi.Business.Concrete
{
    public class UserProfileManager : IUserProfileService
    {
        private IUnitOfWork UnitOfWork { get; }
        private IMapper _mapper;
        private ILoggerService _loggerService;

        public UserProfileManager(IUnitOfWork unitOfWork, IMapper mapper, ILoggerService loggerService)
        {
            UnitOfWork = unitOfWork;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        public void Add(UserProfileDtoForAdd profileDto)
        {
            var profile = _mapper.Map<MezuniyetSistemi.Entities.Concrete.UserProfile>(profileDto);
            var result = CheckUserProfileByUserId(profileDto.UserId, false);
            if(result)
            {
                throw new Exception($"userId: {profileDto.UserId} kullanıcısı kayıtlıdır. Lütfen güncelleme işlemini deneyiniz!");
            }
            UnitOfWork.Profiles.Add(profile);
            UnitOfWork.Save();
        }

        public void Delete(MezuniyetSistemi.Entities.Concrete.UserProfile profile)
        {
            UnitOfWork.Profiles.Delete(profile);
            UnitOfWork.Save();
        }

        public IList<MezuniyetSistemi.Entities.Concrete.UserProfile> FindAll(bool trackChanges)
        {
            return UnitOfWork.Profiles.FindAll(trackChanges).ToList();
        }

        public MezuniyetSistemi.Entities.Concrete.UserProfile FindById(int id, bool trackChanges)
        {
            UserProfile profile = CheckUserProfileById(id, trackChanges);
            return profile;
        }

        public void Update(int id, UserProfileDtoForUpdate profileDto, bool trackChanges)
        {
            UserProfile profile = CheckUserProfileById(id, trackChanges);

            var mappedProfile = _mapper.Map<UserProfileDtoForUpdate, MezuniyetSistemi.Entities.Concrete.UserProfile>(profileDto, profile);

            UnitOfWork
                .Profiles
                .Update(mappedProfile);

            UnitOfWork.Save();
        }

        private UserProfile CheckUserProfileById(int id, bool trackChanges)
        {
            var profile = UnitOfWork
                            .Profiles
                            .FindByCondition(x => x.Id == id, trackChanges)
                            .SingleOrDefault();
            if (profile == null)
            {
                string message = $"{id} kayitli bir kullanici bulunamadi!";
                _loggerService.LogError(message);
                throw new Exception(message);
            }

            return profile;
        }
        private bool CheckUserProfileByUserId(int userId, bool trackChanges)
        {
            var profile = UnitOfWork
                            .Profiles
                            .FindByCondition(x => x.UserId == userId, trackChanges)
                            .SingleOrDefault();
            if (profile == null)
            {
                return false;
            }

            return true;
        }

        public PagedList<UserProfile> FindAllWithPagination(UserProfileParameters parameters, bool trackChanges)
        {
            var profiles = UnitOfWork.Profiles.GetAllWithPagination(parameters, trackChanges);
            return profiles;
        }

        public UserProfile GetByUserId(int userId, bool trackChanges)
        {
            var result = CheckUserProfileByUserId (userId, trackChanges);
            if (!result)
                throw new Exception($"userId: {userId} kullanici bulunamadi!");
            var profile = UnitOfWork
                            .Profiles
                            .FindByCondition(x => x.UserId == userId, trackChanges)
                            .SingleOrDefault();

            return profile;
        }

        public UserProfile FindByIdWithAllProp(int id, bool trackChanges)
        {
            var result = CheckUser(id);
            if (result)
            {
                var profile = UnitOfWork
                    .Profiles
                    .GetWithSpecialityAndCompanies(id, trackChanges).FirstOrDefault();
                return profile;
            }

            throw new Exception("Beklenmeyen bir hata ile karşılaşıldı!");
        }

        private bool CheckUser(int id)
        {
            var profile = UnitOfWork.Profiles.FindByCondition(x=>x.Id==id, false);
            if (profile == null)
                throw new Exception("Verilen parametrede kayıt bulunamadı!");

            return true;
        }
    }
}
