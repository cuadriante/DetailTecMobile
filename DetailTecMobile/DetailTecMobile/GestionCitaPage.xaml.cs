using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace DetailTecMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GestionCitaPage : ContentPage
    {

        ObservableCollection<Models.Cita> citas;

        public GestionCitaPage()
        {
            InitializeComponent();

            citas = new ObservableCollection<Models.Cita>
            {
                new Models.Cita{placaVehiculo = "JAM-123", tipoLavado = 1, hora = DateTime.Now, medioPago = "dolares" },
                new Models.Cita {placaVehiculo = "ADR-555", IDSucursal = 1, tipoLavado = 1, hora = DateTime.Now, medioPago = "dolares" },
                new Models.Cita{placaVehiculo = "UWU-123", IDSucursal = 1, tipoLavado = 1, hora = DateTime.Now, medioPago = "dolares"},
                new Models.Cita{placaVehiculo = "76456745", IDSucursal = 1, tipoLavado = 1, hora = DateTime.Now, medioPago = "dolares" },

            };

            citaCollectionView.ItemsSource = citas;

 
        }



        //   protected override async void OnAppearing()
        /// <summary>
        /// /
        /// </summary>
        // Retrieve all the notes from the database, and set them as the
        // data source for the CollectionView.
        //       CollectionView collectionView = new CollectionView();
        //     collectionView.ItemsSource = await App.Database.Listar();
        //   }

        private async void BackButton_Clicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new MenuPage());
            }
        }
}