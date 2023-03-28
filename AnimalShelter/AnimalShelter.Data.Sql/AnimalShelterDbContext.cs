using AnimalShelter.Data.Sql.DAO;
using AnimalShelter.Data.Sql.DAOConfigurations;
using Microsoft.EntityFrameworkCore;


namespace AnimalShelter.Data.Sql
{
    public class AnimalShelterDbContext : DbContext
    {
        public AnimalShelterDbContext(DbContextOptions<AnimalShelterDbContext> options) : base(options) { }

        //Ustawienie klas z folderu DAO jako tabele bazy danych
        public virtual DbSet<AdoptionContract> AdoptionContract { get; set; }
        public virtual DbSet<Animal> Animal { get; set; } 
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; } 
        public virtual DbSet<EmployeeAnimal> EmployeeAnimal { get; set; } 
        public virtual DbSet<Volunteer> Volunteer { get; set; } 
        public virtual DbSet<VolunteerAnimal> VolunteerAnimal { get; set; } 

        //Przykład konfiguracji modeli/encji poprzez klasy konfiguracyjne z folderu DAOConfigurations
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AdoptionContractConfiguration());
            builder.ApplyConfiguration(new AnimalConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new EmployeeAnimalConfiguration());
            builder.ApplyConfiguration(new VolunteerConfiguration());
            builder.ApplyConfiguration(new VolunteerAnimalConfiguration());
        }

    }
}
