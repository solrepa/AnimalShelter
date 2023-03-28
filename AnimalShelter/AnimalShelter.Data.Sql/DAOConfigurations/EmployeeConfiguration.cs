using AnimalShelter.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Data.Sql.DAOConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //metoda IsRequired() wymusza w bazie ustawienie koleumny na NotNull
            builder.Property(c => c.EmployeeFirstName).IsRequired();
            builder.Property(c => c.EmployeeLastName).IsRequired();
            builder.Property(c => c.EmployeeJobPosition).IsRequired();
            builder.ToTable("Employee");
        }
    }

}
