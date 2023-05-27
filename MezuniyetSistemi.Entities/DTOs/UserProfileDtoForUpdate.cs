using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Entities.DTOs
{
    public record UserProfileDtoForUpdate
    {
        [DisplayName("Id")]
        [Required(ErrorMessage = "{0} alani boş geçilmemelidir.")]
        public int Id { get; init; }
        public int UserId { get; set; }

        [DisplayName("Ogrenci Numarasi")]
        [Required(ErrorMessage = "{0} alani boş geçilmemelidir.")]
        public int StudentNumber { get; init; }
        [DisplayName("FirstName")]
        [Required(ErrorMessage = "{0} alani boş geçilmemelidir.")]
        [MaxLength(25, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string FirstName { get; init; }
        [DisplayName("LastName")]
        [Required(ErrorMessage = "{0} alani boş geçilmemelidir.")]
        [MaxLength(25, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string LastName { get; init; }
        [DisplayName("FirstName")]
        [Required(ErrorMessage = "{0} alani boş geçilmemelidir.")]
        public DateTime EntryDate { get; init; }
        [DisplayName("FirstName")]
        [Required(ErrorMessage = "{0} alani boş geçilmemelidir.")]
        public DateTime GraduationDate { get; init; }
    }
}
