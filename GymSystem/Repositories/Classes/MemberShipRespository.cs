using GymSystem.Entites;
using GymSystem.Repositories.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Repositories.Classes
{
    public class MemberShipRespository : IMemberShipRepostory
    {
        private readonly GymContext _dbContext;

        public MemberShipRespository(GymContext dbContext)
        {
            _dbContext = dbContext; 
           
        }

        

        public async Task<bool> AnyAsync(Expression<Func<MemberShip, bool>> Predicate, CancellationToken ct)
        {
            return await _dbContext.Memberships.AnyAsync(Predicate, ct);
        }
    }
}
