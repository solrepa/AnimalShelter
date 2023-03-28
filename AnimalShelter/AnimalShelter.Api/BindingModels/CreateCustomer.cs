using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Api.BindingModels
{
    public class CreateCustomer
    {

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string CustomerFirstName { get; set; } = default!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string CustomerLastName { get; set; } = default!;

        [Required]
        public int CustomerContactNumber { get; set; }
    }
}
