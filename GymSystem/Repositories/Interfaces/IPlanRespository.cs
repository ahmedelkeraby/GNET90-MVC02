using GymSystem.Entites;

namespace GymSystem.Repositories.Interfaces
{
    public interface IPlanRespository
    {
        Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default);

        Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<int> UpdatedAsync(CancellationToken ct = default);

    }
}
