using AnimalShelter.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Data.Sql.DAOConfigurations
{
    public class EmployeeAnimalConfiguration : IEntityTypeConfiguration<EmployeeAnimal>
    {
        public void Configure(EntityTypeBuilder<EmployeeAnimal> builder)
        {
            builder.HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeAnimalKeys)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.EmployeeId);
            builder.HasOne(x => x.Animal)
                .WithMany(x => x.EmployeeAnimalKeys)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.AnimalId);
            builder.ToTable("EmployeeAnimal");
        }

    }

}
