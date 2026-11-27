using GymSystem.Entites;
using GymSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Repositories.Classes
{
    public class PlanRespository : IPlanRespository
    {
        private readonly GymContext _dbContext;

        public PlanRespository(GymContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default) => await _dbContext.Plans.AsNoTracking().ToListAsync(ct);

        public async Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbContext.Plans.FindAsync([id], ct);
        }

        public async Task<int> UpdatedAsync(CancellationToken ct = default)
        {
            try
            {
                return await _dbContext.SaveChangesAsync(ct);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            
            }
        }
    }
}
