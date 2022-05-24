using Application.Dto;
using Application.Services;

namespace Application.Interfaces
{
    public interface IVeiculoService
    {
        Task<ResultService<bool>> DeleteAsync(int id);
        Task<ResultService<IEnumerable<VeiculosDto>>> GetAllAsync();
        Task<ResultService<VeiculosDto>> GetByIdAsync(int id);
        Task<ResultService<bool>> SaveAsync(VeiculosDto veiculoDto);
        Task<ResultService<bool>> UpdateAsync(VeiculosDto veiculoDto);
    }
}
