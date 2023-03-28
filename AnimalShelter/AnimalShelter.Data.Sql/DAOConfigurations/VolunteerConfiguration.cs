using AnimalShelter.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalShelter.Data.Sql.DAOConfigurations
{
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            //metoda IsRequired() wymusza w bazie ustawienie koleumny na NotNull
            builder.Property(c => c.VolunteerFirstName).IsRequired();
            builder.Property(c => c.VolunteerLastName).IsRequired();
            builder.Property(c => c.VolunteerJobPosition).IsRequired();
            builder.ToTable("Volunteer");
        }
    }

}
