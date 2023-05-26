using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Entities.DTOs
{
    public record UserProfileDtoForAdd
    {
        public int StudentNumber { get; init; }
        public int UserId { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime EntryDate { get; init; }
        public DateTime GraduationDate { get; init; }
    }
}
