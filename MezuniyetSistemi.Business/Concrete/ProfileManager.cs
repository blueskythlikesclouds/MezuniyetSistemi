using AutoMapper;
using Core.Entities.Concrete;
using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.DataAccess.Concrete;
using MezuniyetSistemi.Entities.Concrete;
using MezuniyetSistemi.Entities.DTOs;
using MezuniyetSistemi.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Business.Concrete
{
    public class ProfileManager : IProfileService
    {
        private IUnitOfWork UnitOfWork { get; }
        private IMapper _mapper;
        private ILoggerService _loggerService;

        public ProfileManager(IUnitOfWork unitOfWork, IMapper mapper, ILoggerService loggerService)
        {
            UnitOfWork = unitOfWork;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        public void Add(UserProfileDtoForAdd profileDto)
        {
            var profile = _mapper.Map<MezuniyetSistemi.Entities.Concrete.UserProfile>(profileDto);
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

            profile = _mapper.Map<MezuniyetSistemi.Entities.Concrete.UserProfile>(profileDto);

            UnitOfWork
                .Profiles
                .Update(profile);

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

        public PagedList<UserProfile> FindAllWithPagination(UserProfileParameters parameters, bool trackChanges)
        {
            var profiles = UnitOfWork.Profiles.GetAllWithPagination(parameters, trackChanges);
            return profiles;
        }
    }
}
