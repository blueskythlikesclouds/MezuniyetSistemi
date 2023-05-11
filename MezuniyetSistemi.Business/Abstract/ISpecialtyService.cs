using MezuniyetSistemi.Entities.Concrete;

namespace MezuniyetSistemi.Business.Abstract
{
    public interface ISpecialtyService
    {
        IList<Specialty> FindAll(bool trackChanges);
        //PagedList<Specialty> FindAllWithPagination(UserProfileParameters parameters, bool trackChanges);
        Specialty FindById(int id, bool trackChanges);
        void Add(Specialty specialty);
        void Update(int id, Specialty specialty, bool trackChanges);
        void Delete(int id);
    }

}
