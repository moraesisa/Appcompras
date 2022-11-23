using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Appcompras.Model;
using SQLite;

namespace Appcompras.Helper
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }
        public Task<int> insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public void update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE id= ?";

            _conn.QueryAsync<Produto>(sql, p.Descricao, p.Preco, p.ID);
        }

      
        public Task<List<Produto>> getAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        public void delete(int Id)
        {
            _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
    }
}
