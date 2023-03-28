using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data.Sql.DAO
{
    public class Customer
    {
        public Customer()
        {
            AdoptionContracts = new List<AdoptionContract>();
        }

        public int CustomerId { get; set; } = default!;
        public string CustomerFirstName { get; set; } = default!;
        public string CustomerLastName { get; set; } = default!;
        public int CustomerContactNumber { get; set; } = default!;

        public virtual ICollection<AdoptionContract> AdoptionContracts { get; set; }
    }
}
