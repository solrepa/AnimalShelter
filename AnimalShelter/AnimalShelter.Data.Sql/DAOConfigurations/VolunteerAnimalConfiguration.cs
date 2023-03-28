using AnimalShelter.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Data.Sql.DAOConfigurations
{
    public class VolunteerAnimalConfiguration : IEntityTypeConfiguration<VolunteerAnimal>
    {
        public void Configure(EntityTypeBuilder<VolunteerAnimal> builder)
        {
            builder.HasOne(x => x.Volunteer)
                .WithMany(x => x.VolunteerAnimalKeys)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.VolunteerId);
            builder.HasOne(x => x.Animal)
                .WithMany(x => x.VolunteerAnimalKeys)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.AnimalId);
            builder.ToTable("VolunteerAnimal");
        }

    }

}
