using GymSystem.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GymSystem
{
    public class GymContext : DbContext 
    {
       

        public GymContext(DbContextOptions<GymContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        internal async Task<int> SaveChanges(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public DbSet<Member> Members => Set<Member>();
        public DbSet<Trainer> Trainers => Set<Trainer>();
        public DbSet<Plan> Plans => Set<Plan>();
        public DbSet<MemberShip> Memberships => Set<MemberShip>();
        public DbSet<Session> Sessions => Set<Session>();
    }
}
