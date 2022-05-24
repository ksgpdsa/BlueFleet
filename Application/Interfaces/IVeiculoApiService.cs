using Application.Dto;
using Application.Services;

namespace Application.Interfaces
{
    public interface IVeiculoApiService
    {
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<IEnumerable<VeiculosDto>>> GetAllAsync();
        Task<ResultService<VeiculosDto>> GetByIdAsync(int id);
        Task<ResultService> SaveAsync(VeiculosDto veiculoDto);
        Task<ResultService> UpdateAsync(VeiculosDto veiculoDto);
    }
}
