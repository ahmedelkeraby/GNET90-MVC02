using GymSystem.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymSystem.Configurations
{
    public class TrainerConfigurations : GymUserConfigurations<Trainer>, IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {

            builder.Property(T => T.CreatedAt).HasDefaultValueSql("GETDATE()");



            builder.HasMany(T => T.Sessions)
                   .WithOne(S => S.Trainer)
                   .HasForeignKey(S => S.TrainerID)
                   .OnDelete(DeleteBehavior.Cascade);
            
            base.Configure(builder);

        }
    }
}
