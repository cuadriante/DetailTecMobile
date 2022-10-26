﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DetailTecMobile.Services
{
    public class SQLDBHelper
    {
        private readonly SQLiteAsyncConnection db;

        public SQLDBHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Models.Cita>();
        }

        public Task<Models.Cita> Obtener(string d)
        {
            return db.Table<Models.Cita>()
                .Where(i => i.id == d)
                            .FirstOrDefaultAsync();
        }
        public Task<int> Insertar(Models.Cita cita)
        {
            return db.InsertAsync(cita);
        }

        public Task<List<Models.Cita>> Listar()
        {
            return db.Table<Models.Cita>().ToListAsync();
        }

        public Task<int> Modificar(Models.Cita cita)
        {
            return db.UpdateAsync(cita);
        }

        public Task<int> Eliminar(Models.Cita cita)
        {
            return db.DeleteAsync(cita);
        }

    }
}