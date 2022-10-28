using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using DetailTecMobile.Models;

namespace DetailTecMobile.Services
{
    public class SQLDBHelper
    {
        SQLiteAsyncConnection db;

        public SQLDBHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Cliente>();
            db.CreateTableAsync<Sucursal>();
            db.CreateTableAsync<Lavado>();
            db.CreateTableAsync<Trabajador>();
            db.CreateTableAsync<Cita>();
        }

        public  Task<Models.Cita> ObtenerCita(int d)
        {
            return  db.Table<Cita>().Where(i => i.id == d).FirstOrDefaultAsync();
        }
        public  Task<Cliente> ObtenerC(string d)
        {
            return  db.Table<Cliente>().Where(i => i.id == d).FirstOrDefaultAsync();
        }
        public  Task<Sucursal> ObtenerS(int d)
        {
            return  db.Table<Sucursal>().Where(i => i.id == d).FirstOrDefaultAsync();
        }
        public  Task<Trabajador> ObtenerT(string d)
        {
            return  db.Table<Trabajador>().Where(i => i.id == d).FirstOrDefaultAsync();
        }
        public  Task<Lavado> ObtenerL(int d)
        {
            return db.Table<Lavado>().Where(i => i.id == d).FirstOrDefaultAsync();
        }



        public Task<int> Insertar(Cita cita)
        {
            return db.InsertAsync(cita);

        }

        public Task<int> Insertar(Lavado lavado)
        {
            return db.InsertAsync(lavado);

        }

        public Task<int> Insertar(Cliente cliente)
        {
            return db.InsertAsync(cliente);

        }
        public Task<int> Insertar(Sucursal sucursal)
        {
            return db.InsertAsync(sucursal);

        }
        public Task<int> Insertar(Trabajador trabajador)
        {
            return db.InsertAsync(trabajador);

        }


        public  Task<List<Cita>> ListarCita(string cedCli)
        {
            return  db.Table<Cita>().Where(i => i.cedulaCliente == cedCli).ToListAsync();
        }

        public  Task<List<Trabajador>> ListarT()
        {
            return  db.Table<Trabajador>().ToListAsync();
        }

        public  Task<List<Sucursal>> ListarS()
        {
            return  db.Table<Sucursal>().ToListAsync();
        }

        public  Task<List<Cliente>> ListarC()
        {
            return  db.Table<Cliente>().ToListAsync();
        }


        public Task<int> Modificar(Cita cita)
        {
            return db.UpdateAsync(cita);
        }
        public Task<int> Modificar(Cliente cl)
        {
            return db.UpdateAsync(cl);
        }
        public Task<int> Modificar(Sucursal suc)
        {
            return db.UpdateAsync(suc);
        }
        public Task<int> Modificar(Trabajador trab)
        {
            return db.UpdateAsync(trab);
        }

        public Task<int> DeleteAllItems<T>()
        {
            return db.DeleteAllAsync<T>();
        }

    }
}
