using GymSystem.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymSystem.Configurations
{
    public class PlanConfigurations : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.ToTable(TB =>
                TB.HasCheckConstraint("CK_days", "[DurationDays] Between 1 And 365")
             );

            builder.HasMany(P => P.Memberships)
                   .WithOne(Ms => Ms.Plan)
                   .HasForeignKey(Ms => Ms.PlanId)
                   .OnDelete(DeleteBehavior.Restrict);


           
        }
    }
}
