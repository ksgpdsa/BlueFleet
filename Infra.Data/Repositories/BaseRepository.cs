using Dapper;
using Infra.Data.Data;
using Infra.Data.Interfaces;

namespace Infra.Data.Repositories
{
    public class BaseRepository<Classe> : IBaseRepository<Classe> where Classe : class
    {
        private readonly DbSession _db;
        private string Tabela;

        public BaseRepository(DbSession db)
        {
            _db = db;
        }

        public async Task<int> DeleteAsync(int id)
        {
            string query = @"DELETE FROM @tabela WHERE Id = @Id";
            string sql = query.Replace("@tabela", Tabela);
            int result = await _db.Connection.ExecuteAsync(sql: sql, param: new { id }, _db.Transaction);
            return result;
        }

        public async Task<IEnumerable<Classe>> GetAllAsync()
        {
            string query = @"SELECT * FROM @tabela";
            string sql = query.Replace("@tabela", Tabela);
            var result = await _db.Connection.QueryAsync<Classe>(sql: sql, null, _db.Transaction);
            return result;
        }

        public async Task<Classe> GetByIdAsync(int id)
        {
            string query = @"SELECT * FROM @tabela WHERE Id = @Id";
            string sql = query.Replace("@tabela", Tabela);
            var result = await _db.Connection.QueryFirstOrDefaultAsync<Classe>(sql: sql, param: new { id }, _db.Transaction);
            return result;
        }

        public async Task<int> SaveAsync(Classe classe, string campos, string valores)
        {
            string query = @"INSERT INTO @tabela(@campos) VALUES(@valores)";
            string sql = query.Replace("@tabela", Tabela).Replace("@campos", campos).Replace("@valores", valores);
            int result = await _db.Connection.ExecuteAsync(sql: sql, param: classe, _db.Transaction);
            return result;
        }

        public async Task<int> UpdateAsync(Classe classe, string campos)
        {
            string query = @"UPDATE @tabela SET @campos WHERE Id = @Id";
            string sql = query.Replace("@tabela", Tabela).Replace("@campos", campos);
            int result = await _db.Connection.ExecuteAsync(sql: sql, param: classe, _db.Transaction);
            return result;
        }

        public DbSession GetDb()
        {
            return _db;
        }

        public string GetNomeTabela()
        {
            return Tabela;
        }

        public void SetNomeTabela(string nome)
        {
            Tabela = nome;
        }
    }
}