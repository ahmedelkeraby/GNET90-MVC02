using GymSystem.Entites;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Configurations
{
    public class SessionConfigurations : IEntityTypeConfiguration<Session>

    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Session> builder)
        {
            builder.ToTable(TB =>
            {
                TB.HasCheckConstraint("Ck_Capacity", "[Capacity] Between 1 And 25");

                TB.HasCheckConstraint("CK_Session_Dates", "[StartDate] <= [EndDate]");
            });

           
        }
    }
}
