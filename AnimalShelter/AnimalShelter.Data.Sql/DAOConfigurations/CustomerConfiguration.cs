using AnimalShelter.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Data.Sql.DAOConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //metoda IsRequired() wymusza w bazie ustawienie koleumny na NotNull
            builder.Property(c => c.CustomerFirstName).IsRequired();
            builder.Property(c => c.CustomerLastName).IsRequired();
            builder.Property(c => c.CustomerContactNumber).IsRequired();
            builder.ToTable("Customer");
        }
    }

}
