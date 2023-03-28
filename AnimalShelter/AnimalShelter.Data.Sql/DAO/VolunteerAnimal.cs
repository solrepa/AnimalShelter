using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data.Sql.DAO
{
    public class VolunteerAnimal
    {
        public int VolunteerAnimalId { get; set; }
        public int VolunteerId { get; set; } = default!;
        public int AnimalId { get; set; } = default!;

        public virtual Volunteer Volunteer { get; set; } = default!;
        public virtual Animal Animal { get; set; } = default!;
    }
}
