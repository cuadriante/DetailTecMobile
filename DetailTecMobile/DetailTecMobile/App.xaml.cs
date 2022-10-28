using DetailTecMobile.Models;
using DetailTecMobile.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailTecMobile
{
    public partial class App : Application
    {

        private static SQLDBHelper database;

        // Create the database connection as a singleton.
        public static SQLDBHelper Database
        {
            get
            {
                if (database == null)
                {
                    try
                    {
                        Console.WriteLine("Base creada");
                        database = new SQLDBHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DetailTECMobile.db3"));
                        
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Failed to load database.");
                    }


                }
                try
                {
                    database.DeleteAllItems<Cita>();
                    database.DeleteAllItems<Cliente>();
                    database.DeleteAllItems<Trabajador>();
                    database.DeleteAllItems<Lavado>();
                    database.DeleteAllItems<Sucursal>();
                }
                catch (Exception)
                {
                    Console.WriteLine("A");
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new NavigationPage(new GreetPage());
            MainPage = new NavigationPage(new MenuPage("Adri"));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
