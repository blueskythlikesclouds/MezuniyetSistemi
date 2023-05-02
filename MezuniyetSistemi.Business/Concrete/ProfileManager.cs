using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.Entities.Concrete;
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

        public ProfileManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Add(Profile profile)
        {
            UnitOfWork.Profiles.Add(profile);
        }

        public void Delete(Profile profile)
        {
            UnitOfWork.Profiles.Delete(profile);
        }

        public IList<Profile> FindAll(bool trackChanges)
        {
            return UnitOfWork.Profiles.FindAll(trackChanges).ToList();
        }

        public Profile FindById(int id, bool trackChanges)
        {
            return UnitOfWork.Profiles.FindByCondition(x=>x.Id == id, trackChanges).SingleOrDefault();
        }

        public void Update(Profile profile)
        {
            UnitOfWork.Profiles.Update(profile);
        }
    }
}
