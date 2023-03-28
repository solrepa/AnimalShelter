using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data.Sql.DAO
{
    public class AdoptionContract
    {
        public int AdoptionContractId { get; set; }
        public int EmployeeId { get; set; } = default!;
        public int AnimalId { get; set; } = default!;
        public int CustomerId {get; set; } = default!;

        public string AdoptionContractName { get; set; } = default!;

        public virtual Customer Customer { get; set; } = default!;
        public virtual Employee Employee { get; set; } = default!;
        public virtual Animal Animal { get; set; } = default!;
    }
}
