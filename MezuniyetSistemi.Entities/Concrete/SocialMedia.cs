using Core.Entities.Abstract;

namespace MezuniyetSistemi.Entities.Concrete
{
    public class SocialMedia: EntityBase
    {
        public string Url { get; set; }

        // Social Media N - 1 Profile
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}