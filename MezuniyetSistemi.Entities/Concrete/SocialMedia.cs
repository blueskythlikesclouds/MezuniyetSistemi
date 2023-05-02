using Core.Entities.Abstract;

namespace MezuniyetSistemi.Entities.Concrete
{
    public class SocialMedia: EntityBase
    {
        public string Url { get; set; }

        // Social Media N - 1 UserProfile
        public int ProfileId { get; set; }
        public virtual UserProfile Profile { get; set; }
    }
}