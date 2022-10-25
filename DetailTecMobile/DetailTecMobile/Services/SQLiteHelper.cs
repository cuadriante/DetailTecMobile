using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace DetailTecMobile.Services
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Models.Cliente>();
        }

        public Task<Models.Cliente> Obtener(string d)
        {
            return db.Table<Models.Cliente>()
                .Where(i => i.id == d)
                            .FirstOrDefaultAsync();
        }
        public Task<int> Insertar(Models.Cliente cliente)
        {
            return db.InsertAsync(cliente);
        }

        public Task<List<Models.Cliente>> Listar()
        {
            return db.Table<Models.Cliente>().ToListAsync();
        }

        public Task<int> Modificar(Models.Cliente cliente)
        {
            return db.UpdateAsync(cliente);
        }

        public Task<int> Eliminar(Models.Cliente cliente)
        {
            return db.DeleteAsync(cliente);
        }
    }
}
