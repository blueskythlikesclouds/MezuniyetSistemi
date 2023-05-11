using MezuniyetSistemi.Business.Abstract;
using MezuniyetSistemi.DataAccess.Abstract;
using MezuniyetSistemi.Entities.Concrete;

namespace MezuniyetSistemi.Business.Concrete
{
    public class SpecialtyManager : ISpecialtyService
    {
        private IUnitOfWork _unitOfWork { get; }

        public SpecialtyManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Specialty specialty)
        {
            _unitOfWork.Specialties.Add(specialty);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var specialty = _unitOfWork.Specialties.FindByCondition(x => x.Id == id, false).FirstOrDefault();
            if (specialty != null)
            {
                _unitOfWork.Specialties.Delete(specialty);
                _unitOfWork.Save();
            }
        }

        public IList<Specialty> FindAll(bool trackChanges)
        {
            return _unitOfWork.Specialties.FindAll(trackChanges).ToList();
        }

        public Specialty FindById(int id, bool trackChanges)
        {
            return _unitOfWork.Specialties.FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();
        }

        public void Update(int id, Specialty specialty, bool trackChanges)
        {
            _unitOfWork.Specialties.Update(specialty);
            _unitOfWork.Save();
        }
    }
}
