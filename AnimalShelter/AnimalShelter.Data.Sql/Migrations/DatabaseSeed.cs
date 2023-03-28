using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AnimalShelter.Data.Sql.DAO;

namespace AnimalShelter.Data.Sql.Migrations
{
    //klasa odpowiadająca za wypełnienie testowymi danymi bazę danych
    public class DatabaseSeed
    {
        private readonly AnimalShelterDbContext _context;

        //wstrzyknięcie instancji klasy FoodlyDbContext poprzez konstruktor
        public DatabaseSeed(AnimalShelterDbContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            //add Customers
            var customerList = BuildCustomerList();
            _context.Customer.AddRange(customerList);
            _context.SaveChanges();
            
            //add Employees
            var employeeList = BuildEmployeeList();
            _context.Employee.AddRange(employeeList);
            _context.SaveChanges();

            //add Volunteers
            var volunteerList = BuildVolunteerList();
            _context.Volunteer.AddRange(volunteerList);
            _context.SaveChanges();

            //add Animals
            var animalList = BuildAnimalList();
            _context.Animal.AddRange(animalList);
            _context.SaveChanges();

            //add EmployeeAnimal
            //var employeeAnimalList = BuildEmployeeAnimalList(employeeList, animalList);
            //_context.EmployeeAnimal.AddRange(employeeAnimalList);
            //_context.SaveChanges();
            
            ////add VolunteerAnimal
            //var volunteerAnimalList = BuildVolunteerAnimalList(volunteerAnimalList, animalList);
            //_context.VolunteerAnimal.AddRange(volunteerAnimalList);
            //_context.SaveChanges();

            ////add AdoptionContract
            //var adoptionContractList = BuildAdoptionContractList(customerList, employeeList, animalList);
            //_context.AdoptionContract.AddRange(adoptionContractList);
            //_context.SaveChanges();

        }

        private IEnumerable<DAO.Customer> BuildCustomerList()
        {
            Random randomContact = new Random();
            var customerList = new List<DAO.Customer>();
            var customer = new DAO.Customer()
            {
                CustomerFirstName = "Paula",
                CustomerLastName = "Baranowska",
                CustomerContactNumber = randomContact.Next(111111111, 999999999)
            };
            customerList.Add(customer);

            var customer2 = new DAO.Customer()
            {
                CustomerFirstName = "Apolonia",
                CustomerLastName = "Mucha",
                CustomerContactNumber = randomContact.Next(111111111, 999999999)
            };
            customerList.Add(customer2);

            var customer3 = new DAO.Customer()
            {
                CustomerFirstName = "Aldona",
                CustomerLastName = "Przybylska",
                CustomerContactNumber = randomContact.Next(111111111, 999999999)
            };
            customerList.Add(customer3);

            for (int i = 4; i < 11; i++) 
            {
                var customer4 = new DAO.Customer()
                {
                    CustomerFirstName = "firstNameCustomer" + i,
                    CustomerLastName = "lastNameCustomer" + i,
                    CustomerContactNumber = randomContact.Next(111111111, 999999999)
                };
                customerList.Add(customer4);
            }

            return customerList;
        }

        private IEnumerable<DAO.Employee> BuildEmployeeList()
        {
            var employeeList = new List<DAO.Employee>();
            var employee = new DAO.Employee()
            {
                EmployeeFirstName = "Iryna",
                EmployeeLastName = "Sikorska",
                EmployeeJobPosition = "dyrektor"
            };
            employeeList.Add(employee);
            
            //add random employees
            for (int i = 2; i <= 10; i++)
            {
                var employee2 = new DAO.Employee()
                {
                    EmployeeFirstName = "employeeFirstName" + i,
                    EmployeeLastName = "employeeLastName" + i,
                    EmployeeJobPosition = "opiekun"
                };
                employeeList.Add(employee2);
            }

            return employeeList;
        }

        private IEnumerable<DAO.Volunteer> BuildVolunteerList()
        {
            var volunteerList = new List<DAO.Volunteer>();
            var volunteer = new DAO.Volunteer()
            {
                VolunteerFirstName = "Nataniel",
                VolunteerLastName = "Urbaniak",
                VolunteerJobPosition = "opieka nad zwierzem"
            };
            volunteerList.Add(volunteer);

            //add random volunteers
            for (int i = 2; i <= 10; i++)
            {
                var volunteer2 = new DAO.Volunteer()
                {
                    VolunteerFirstName = "volunteerFirstName" + i,
                    VolunteerLastName = "volunteerLastName" + i,
                    VolunteerJobPosition = "opieka nad zwierzem"
                };
                    volunteerList.Add(volunteer2);
            }

            return volunteerList;
        }

        private IEnumerable<DAO.Animal> BuildAnimalList()
        {
            var animalList = new List<DAO.Animal>();

            //add random animals with status "na miejscu"
            for (int i = 1; i <= 5; i++)
            {
                var animal = new DAO.Animal()
                {
                    AnimalName = "animal" + i,
                    AnimalStatus = "na miejscu"
                };
                animalList.Add(animal);
            }

            //add random animals with status "zadoptowane"
            for (int i = 5; i <= 8; i++)
            {
                var animal = new DAO.Animal()
                {
                    AnimalName = "animal" + i,
                    AnimalStatus = "zadoptowane"
                };
                animalList.Add(animal);
            }

            return animalList;
        }

    }

}
