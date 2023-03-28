using AnimalShelter.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Data.Sql.DAOConfigurations
{
    public class AdoptionContractConfiguration : IEntityTypeConfiguration<AdoptionContract>
    {
        public void Configure(EntityTypeBuilder<AdoptionContract> builder)
        {
            builder.HasOne(x => x.Employee)
                .WithMany(x => x.AdoptionContracts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.EmployeeId);
            builder.HasOne(x => x.Customer)
                .WithMany(x => x.AdoptionContracts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.Animal)
                .WithMany(x => x.AdoptionContracts)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.AnimalId);
            builder.ToTable("AdoptionContract");
        }

    }

}

