using Core.Entities.Abstract;

namespace MezuniyetSistemi.Entities.Concrete
{
    public class Image : EntityBase
    {
        public string Path { get; set; }

        // Image N - 1 UserProfile
        public int ProfileId { get; set; }
        public virtual UserProfile Profile { get; set; }
    }
}