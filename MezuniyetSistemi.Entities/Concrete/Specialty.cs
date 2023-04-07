using Core.Entities.Abstract;

namespace MezuniyetSistemi.Entities.Concrete
{
    public class Specialty : EntityBase
    {
        public string Ability { get; set; }
        public string Level { get; set; }
    }
}