using Core.Entities.Abstract;

namespace MezuniyetSistemi.Entities.Concrete
{
    public class Image : EntityBase
    {
        public string Path { get; set; }

        // Image N - 1 Profile
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}