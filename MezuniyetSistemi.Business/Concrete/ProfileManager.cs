using AutoMapper;
using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.DataAccess.Concrete;
using MezuniyetSistemi.Entities.Concrete;
using MezuniyetSistemi.Entities.DTOs;
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

        public ProfileManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            _mapper = mapper;
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
            return UnitOfWork.Profiles.FindByCondition(x=>x.Id == id, trackChanges).SingleOrDefault();
        }

        public void Update(int id, UserProfileDtoForUpdate profileDto, bool trackChanges)
        {
            var profile = UnitOfWork
                .Profiles
                .FindByCondition(x=>x.Id == id,trackChanges)
                .SingleOrDefault();
            if (profile == null)
                throw new ArgumentNullException();

            profile = _mapper.Map<MezuniyetSistemi.Entities.Concrete.UserProfile>(profileDto);

            UnitOfWork
                .Profiles
                .Update(profile);

            UnitOfWork.Save();
        }
    }
}
