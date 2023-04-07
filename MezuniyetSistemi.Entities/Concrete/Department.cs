using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezuniyetSistemi.Entities.Concrete
{

    public class Department : EntityBase
    {
        // Department 1 - 1 Faculty
        public string Name { get; set; }
    }
}