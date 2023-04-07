using MezuniyetSistemi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Business.Abstract
{
    public interface IProfileService
    {
        IEnumerable<Profile> FindAll(bool changes);
        Profile FindById(int id);
        void Add(Profile profile);
        void Update(Profile profile);
        void Delete(Profile profile);
    }
}
