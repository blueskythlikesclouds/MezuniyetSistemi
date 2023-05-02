using Core.Entities.Abstract;

namespace MezuniyetSistemi.Entities.Concrete
{
    public class Faculty : EntityBase
    {
        // Faculty 1 - N UserProfile
        // Faculty 1 - N Department
        public string Name { get; set; }
    }
}