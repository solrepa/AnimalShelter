using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data.Sql.DAO
{
    public class EmployeeAnimal
    {
        public int EmployeeAnimalId { get; set; }
        public int EmployeeId { get; set; } = default!;
        public int AnimalId { get; set; } = default!;

        public virtual Employee Employee { get; set; } = default!;
        public virtual Animal Animal { get; set; } = default!;
    }
}
