using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data.Sql.DAO
{
    public class Animal
    {
        public Animal()
        {
            AdoptionContracts = new List<AdoptionContract>();
            EmployeeAnimalKeys = new List<EmployeeAnimal>();
            VolunteerAnimalKeys = new List<VolunteerAnimal>();
        }

        public int AnimalId { get; set; }
        public string AnimalName { get; set; } = default!;
        public string? AnimalAge { get; set; }
        public string AnimalStatus { get; set; } = default!;

        public virtual ICollection<AdoptionContract> AdoptionContracts { get; set; }
        public virtual ICollection<EmployeeAnimal> EmployeeAnimalKeys { get; set; }
        public virtual ICollection<VolunteerAnimal> VolunteerAnimalKeys { get; set; }
    }
}
