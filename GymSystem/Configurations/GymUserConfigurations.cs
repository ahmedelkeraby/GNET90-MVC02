
using GymSystem.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
namespace GymSystem.Configurations

{
    public class GymUserConfigurations<T> : IEntityTypeConfiguration<T> where T : GymUser

    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
          builder.Property(u => u.Name).HasColumnType("Varchar").HasMaxLength(50);
          builder.Property(u => u.Phone).HasColumnType("Varchar").HasMaxLength(11);

          builder.HasIndex(u => u.Email).IsUnique();
          builder.HasIndex(u => u.Phone).IsUnique();

            builder.ToTable(TB =>
            {
                TB.HasCheckConstraint(
                    "Ck_Email",
                    "Email LIKE '_%@_%._%'"
                );

                TB.HasCheckConstraint(
                    "Ck_Phone",
                    "(Phone LIKE '010%' OR Phone LIKE '011%' OR Phone LIKE '012%' OR Phone LIKE '015%') AND LEN(Phone) = 11"
                );
            });

            builder.ComplexProperty(u => u.Address, a =>
            {
                a.Property(x => x.City).HasMaxLength(50);
                a.Property(x => x.Street).HasMaxLength(100);
            });

        }
    }
}
