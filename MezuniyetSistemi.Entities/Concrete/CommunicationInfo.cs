using Core.Entities.Abstract;

namespace MezuniyetSistemi.Entities.Concrete
{
    public class CommunicationInfo : EntityBase
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        // Commu N - 1 UserProfile
        public int ProfileId { get; set; }
        public virtual UserProfile Profile { get; set; }
    }
}