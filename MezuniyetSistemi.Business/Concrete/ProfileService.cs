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
    public class ProfileService : IProfileService
    {
        private readonly IProfileDal _profileDal;

        public ProfileService(IProfileDal profileDal)
        {
            _profileDal = profileDal;
        }

        public void Add(Profile profile)
        {
            _profileDal.Add(profile);
        }

        public void Delete(Profile profile)
        {
            _profileDal.Delete(profile);
        }

        public IEnumerable<Profile> FindAll(bool changes)
        {
            return _profileDal.FindAll(changes);
        }

        public Profile FindById(int id)
        {
            return _profileDal.FindByCondition(x=>x.Id == id).SingleOrDefault();
        }

        public void Update(Profile profile)
        {
           _profileDal.Update(profile);
        }
    }
}
