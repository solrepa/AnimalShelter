using System;

namespace AnimalShelter.Api.ViewModels
{
    public class CustomersViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; } = default!;
        public string CustomerLastName { get; set; } = default!;
        public int CustomerContactNumber { get; set; }
    }
}
