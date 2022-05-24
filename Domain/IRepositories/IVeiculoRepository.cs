using Domain.Models;

namespace Domain.IRepositories
{
    public interface IVeiculoRepository
    {
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Veiculo>> GetAllAsync();
        Task<Veiculo> GetByIdAsync(int id);
        Task<bool> SaveAsync(Veiculo veiculo);
        Task<bool> UpdateAsync(Veiculo veiculo);
    }
}
