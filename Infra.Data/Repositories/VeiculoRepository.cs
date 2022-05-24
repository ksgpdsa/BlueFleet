using Domain.IRepositories;
using Domain.Models;
using Infra.Data.Data;
using Infra.Data.Interfaces;

namespace Infra.Data.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {

        private readonly IBaseRepository<Veiculo> _baseRepository;
        private readonly DbSession _db;
        private readonly string _tabela;

        public VeiculoRepository(IBaseRepository<Veiculo> baseRepository)
        {
            _baseRepository = baseRepository;
            _baseRepository.SetNomeTabela("Veiculos");
            _db = _baseRepository.GetDb();
            _tabela = _baseRepository.GetNomeTabela();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _baseRepository.DeleteAsync(id) > 0;
        }

        public Task<IEnumerable<Veiculo>> GetAllAsync()
        {
            return _baseRepository.GetAllAsync();
        }

        public Task<Veiculo> GetByIdAsync(int id)
        {
            return _baseRepository.GetByIdAsync(id);
        }

        public async Task<bool> SaveAsync(Veiculo veiculo)
        {
            string campos = "Placa, Montadora, Modelo";
            string valores = "@Placa, @Montadora, @Modelo";
            return await _baseRepository.SaveAsync(veiculo, campos, valores) > 0;
        }

        public async Task<bool> UpdateAsync(Veiculo veiculo)
        {
            string campos = "Placa = @Placa, Montadora = @Montadora, Modelo = @Modelo";
            return await _baseRepository.UpdateAsync(veiculo, campos) > 0;
        }
    }
}
