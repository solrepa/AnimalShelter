using System;
using System.Threading.Tasks;
using AnimalShelter.Api.BindingModels;
using AnimalShelter.Api.ViewModels;
using AnimalShelter.Api.Validation;
using AnimalShelter.Data.Sql;
using AnimalShelter.Data.Sql.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AnimalShelter.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]


    public class CustomersController : Controller
    {
        private readonly AnimalShelterDbContext _context;

        public CustomersController(AnimalShelterDbContext context)
        {
            _context = context;
        }

        // Show all customers
        [HttpGet("allCustomers")]
        public async Task<IActionResult> allCustomers() 
        {
            var customers = await _context.Customer.ToListAsync();
            if (customers != null) 
            {
                return Ok(customers);
            }

            return NotFound();
        }

        // Show customer by id
        [HttpGet("{customerId:int}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerId);

            if (customer != null)
            {
                return Ok(new CustomersViewModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerFirstName = customer.CustomerFirstName,
                    CustomerLastName = customer.CustomerLastName,
                    CustomerContactNumber = customer.CustomerContactNumber
                });
            }

            return NotFound();
        }

        //show customer by name
        [HttpGet("name/{customerFirstName}")]
        public async Task<IActionResult> GetCustomerByFirstName(string customerFirstName)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(x => x.CustomerFirstName == customerFirstName);

            if (customer != null)
            {
                return Ok(new CustomersViewModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerFirstName = customer.CustomerFirstName,
                    CustomerLastName = customer.CustomerLastName,
                    CustomerContactNumber = customer.CustomerContactNumber
                });
            }
            return NotFound();
        }

        //edit customer by id
        [ValidateModel]
        [HttpPut("edit/{customerId}", Name = "EditCustomer")]
        public async Task<IActionResult> Put([FromBody] EditCustomer editCustomer, int customerId)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            customer.CustomerFirstName = editCustomer.CustomerFirstName;
            customer.CustomerLastName = editCustomer.CustomerLastName;
            customer.CustomerContactNumber = editCustomer.CustomerContactNumber;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //create customer
        [ValidateModel]
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CreateCustomer createCustomer)
        {
            var customer = new Customer
            {
                CustomerFirstName = createCustomer.CustomerFirstName,
                CustomerLastName = createCustomer.CustomerLastName,
                CustomerContactNumber = createCustomer.CustomerContactNumber
            };

            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();

            return Created(customer.CustomerId.ToString(), new CustomersViewModel
            {
                CustomerId = customer.CustomerId,
                CustomerFirstName = customer.CustomerFirstName,
                CustomerLastName = customer.CustomerLastName,
                CustomerContactNumber = customer.CustomerContactNumber
            });

        }


        //delete customer by id 
        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        {
            var customer = await _context.Customer.FindAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
