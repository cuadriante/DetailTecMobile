using DetailTecMobile.Services;
using System;
using System.Data;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailTecMobile
{
    public partial class App : Application
    {
        static SQLiteHelper db;

        public static SQLiteHelper Db
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DetailTEC.db3"));
                }
                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new GreetPage();
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
