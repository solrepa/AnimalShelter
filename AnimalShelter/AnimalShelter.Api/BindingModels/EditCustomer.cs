using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace AnimalShelter.Api.BindingModels
{
    public class EditCustomer
    {

        [Required]
        [StringLength(50, MinimumLength =2)]
        [Display(Name = "CustomerFirstName")]
        public string CustomerFirstName { get; set; } = default!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "CustomerLastName")]
        public string CustomerLastName { get; set; } = default!;

        [Required]

        [Display(Name = "CustomerContactNumber")]
        public int CustomerContactNumber { get; set; } = default!;
    }

    public class EditCustomerValidator : AbstractValidator<EditCustomer> 
    {
        public EditCustomerValidator() 
        {
            RuleFor(x => x.CustomerFirstName).NotNull();
            RuleFor(x => x.CustomerLastName).NotNull();
            RuleFor(x => x.CustomerContactNumber).NotNull();
        }
    }
}
