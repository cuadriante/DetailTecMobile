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

        string currentUser;

        public GestionCitaPage(string user)
        {
            currentUser = user;
            InitializeComponent();
            /*
            citas = new ObservableCollection<Models.Cita>
             {
             new Models.Cita{placaVehiculo = "JAM-123", tipoLavado = 1, hora = DateTime.Now, medioPago = "Tarjeta", estado = "Finalizada"},
             new Models.Cita {placaVehiculo = "ADR-555", IDSucursal = 1, tipoLavado = 1, hora = DateTime.Now, medioPago = "Efectivo", estado = "Pendiente" },
             new Models.Cita{placaVehiculo = "UWU-123", IDSucursal = 1, tipoLavado = 1, hora = DateTime.Now, medioPago = "Puntos", estado = "Finalizada"},
            new Models.Cita{placaVehiculo = "76456745", IDSucursal = 1, tipoLavado = 1, hora = DateTime.Now, medioPago = "Tarjeta", estado = "Finalizada" },

             };

            citaCollectionView.ItemsSource = citas;
            */
           // InsertarCita();

            
 
        }

        protected override async void OnAppearing()
        {
            try
            {
                //base.OnAppearing();
                //citaCollectionView.ItemsSource = await App.Database.Listar();
            }
            catch 
            {

            }
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
                await Navigation.PushAsync(new MenuPage(currentUser));
            }

        private async void AgendarButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ModificarCitaPage(currentUser, null));
        }

        private async void citaCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var itemSelected = e.CurrentSelection[0] as Models.Cita;
            if (itemSelected != null)
            {
                bool mod = await DisplayAlert("DETALLES DE CITA", $" Vehiculo: {itemSelected.placaVehiculo} \n" +
                    $" Fecha: {itemSelected.hora} \n Tipo Lavado {itemSelected.tipoLavado} \n Medio de Pago: {itemSelected.medioPago} \n " +
                    $"Sucursal: {itemSelected.IDSucursal}", "Modificar", "Ok");
                if (mod)
                {
                    await Navigation.PushAsync(new ModificarCitaPage(currentUser, itemSelected));
                }

            }
              

        }

        async void InsertarCita()
        {   /*
            await App.Database.Insertar(new Models.Cita
            {
                id = "1",
                cedulaCliente = "118460116",
                placaVehiculo = "JAM-123",
                IDSucursal = 1,
                tipoLavado = 1,
                fecha = DateTime.Now,
                hora = DateTime.Now,
                medioPago = "dolares"
            });
            */
        }
        }
}