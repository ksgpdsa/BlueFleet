using Infra.Data.Data;

namespace Infra.Data.Interfaces
{
    public interface IBaseRepository<Classe> where Classe : class
    {
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<Classe>> GetAllAsync();
        Task<Classe> GetByIdAsync(int id);
        Task<int> SaveAsync(Classe classe, string campos, string valores);
        Task<int> UpdateAsync(Classe classe, string campos);
        DbSession GetDb();
        string GetNomeTabela();
        void SetNomeTabela(string nomeTabela);
    }
}
