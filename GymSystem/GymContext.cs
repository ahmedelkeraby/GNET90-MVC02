using GymSystem.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GymSystem
{
    public class GymContext : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GymDb;Trusted_Connection=True;TrustserverCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Member> Members => Set<Member>();
        public DbSet<Trainer> Trainers => Set<Trainer>();
        public DbSet<Plan> Plans => Set<Plan>();
        public DbSet<MemberShip> Memberships => Set<MemberShip>();
        public DbSet<Session> Sessions => Set<Session>();
    }
}
