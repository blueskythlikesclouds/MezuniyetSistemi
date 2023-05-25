using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace MezuniyetSistemi.Entities.Concrete
{
    public class UserProfile : EntityBase
    {
        // Duruma gore cikarilabilir
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime GraduationDate { get; set; }

        // Department 1 - N UserProfile
        //public int DepartmentId { get; set; }
        //public virtual Department Department { get; set; }

        public int UserId { get; set; }
        public virtual User? User { get; set; }

        //public virtual ICollection<SocialMedia> SocialMedias { get; set; }

        //public virtual ICollection<Image> Images { get; set; }

        //public virtual ICollection<Specialty> Specialties { get; set; }

        //public virtual ICollection<Company> Companies { get; set; }
    }
}