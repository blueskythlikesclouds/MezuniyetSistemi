using Core.Entities.Abstract;

namespace MezuniyetSistemi.Entities.Concrete
{
    public class Message : EntityBase
    {
        // Message N - N Profile
        public string Title { get; set; }
        public string Content { get; set; }
        public string SendDate { get; set; }
    }
}