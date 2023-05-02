using Core.Entities.Abstract;

namespace MezuniyetSistemi.Entities.Concrete
{
    public class Company : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        //public int ProfileId { get; set; }
        //public virtual UserProfile UserProfile { get; set; }
    }
}