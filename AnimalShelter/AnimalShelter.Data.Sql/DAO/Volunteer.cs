using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data.Sql.DAO
{
    public class Volunteer
    {
        public Volunteer()
        {
            VolunteerAnimalKeys = new List<VolunteerAnimal>();
        }
        public int VolunteerId { get; set; }
        public string VolunteerFirstName { get; set; } = default!;
        public string VolunteerLastName { get; set; } = default!;
        public string VolunteerJobPosition { get; set; } = default!;
        public virtual ICollection<VolunteerAnimal> VolunteerAnimalKeys { get; set; }
    }
}
