using System.Collections.Generic;

namespace AnimalShelter.Data.Sql.DAO
{
    public class Employee
    {
        public Employee()
        {
            AdoptionContracts = new List<AdoptionContract>();
            EmployeeAnimalKeys = new List<EmployeeAnimal>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; } = default!;
        public string EmployeeLastName { get; set; } = default!;
        public string EmployeeJobPosition { get; set; } = default!;

        public virtual ICollection<AdoptionContract> AdoptionContracts { get; set; }
        public virtual ICollection<EmployeeAnimal> EmployeeAnimalKeys { get; set; }
    }
}
