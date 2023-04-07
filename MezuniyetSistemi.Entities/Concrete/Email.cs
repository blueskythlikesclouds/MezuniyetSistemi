using Core.Entities.Abstract;

namespace MezuniyetSistemi.Entities.Concrete
{
    public class Email : EntityBase
    {
        // Email N - N Profile
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
    }
}