using GymSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GymSystem.Entites;
namespace GymSystem.Configurations
{
    public class MemberConfigurations :GymUserConfigurations<Member>, IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(M => M.CreatedAt)
                .HasColumnName("JoinDate")
                .HasDefaultValueSql("GETDATE()");


            builder.HasMany(M=>M.Memberships)
                   .WithOne(Ms=>Ms.Member)
                   .HasForeignKey(Ms=>Ms.MemberId)
                   .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
