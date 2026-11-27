using GymSystem.Entites;
using System.Linq.Expressions;

namespace GymSystem.Repositories.Interfaces
{
    public interface IMemberShipRepostory
    {
        Task<bool> AnyAsync(Expression<Func<MemberShip, bool>>  Predicate, CancellationToken ct);
    }
}
