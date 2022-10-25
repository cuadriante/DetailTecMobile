using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace DetailTecMobile
{
    public  class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Models.ClienteModel>();
        }

        public Task<Models.ClienteModel> Obtener(string d)
        {
            return db.Table<Models.ClienteModel>()
                .Where(i => i.id == d)
                            .FirstOrDefaultAsync();
        }
        public Task<int> Insertar(Models.ClienteModel cliente)
        {
            return db.InsertAsync(cliente);
        }

        public Task<List<Models.ClienteModel>>Listar()
        {
            return db.Table<Models.ClienteModel>().ToListAsync();
        }

        public Task<int> Modificar(Models.ClienteModel cliente)
        {
            return db.UpdateAsync(cliente);
        }

        public Task<int> Eliminar(Models.ClienteModel cliente)
        {
            return db.DeleteAsync(cliente);
        }
    }
}
