using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using DatePicker = Xamarin.Forms.DatePicker;
using Entry = Xamarin.Forms.Entry;
using Picker = Xamarin.Forms.Picker;
using TimePicker = Xamarin.Forms.TimePicker;

namespace DetailTecMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    // Descripción: Página para la posibilidad de modificación de datos de cita agendada previamente, datos obtenidos de la base de datos.
    public partial class ModificarCitaPage : ContentPage
    {

        Button backButton;

        Button saveButton;

        Label nuevaCitaTitleLabel;

        StackLayout layout = new StackLayout();

        string currentUser;

        Entry placaVehiculoEntry;

        List<string> sucursales = new List<string>();

        List<string> tiposDeLavado = new List<string>();

        List<string> modosDePago = new List<string>();

        DatePicker datePicker;

        TimePicker timePicker;

        string currentParametro;

        // Descripción: Inicialización de página para visualización de puntos segpun el usuario seleccionado.
        public ModificarCitaPage(string user, Models.Cita citaActual)
        {
            currentUser = user;
            InitializeComponent();

            modosDePago.Add("Efectivo");
            modosDePago.Add("Tarjeta");
            modosDePago.Add("Puntos");

            tiposDeLavado.Add("Profundo");
            tiposDeLavado.Add("Simple");

            sucursales.Add("Sucu 1");
            sucursales.Add("Lavados Lindos");


            nuevaCitaTitleLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Nueva Cita",
                FontSize = 48

            };

            placaVehiculoEntry = new Entry()
            {
                //  HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = "Placa Vehículo",
                MaxLength = 20,
            };

            Picker modoDePagoPicker = new Picker
            {
                Title = "Modo de Pago",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string modoDePago in modosDePago)
            {
                modoDePagoPicker.Items.Add(modoDePago);
            }

            Picker tipoLavadoPicker = new Picker
            {
                Title = "Tipo de Lavado",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string tipoLavado in tiposDeLavado)
            {
                tipoLavadoPicker.Items.Add(tipoLavado);
            }


            Picker sucursalPicker = new Picker
            {
                Title = "Sucursal",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string sucursal in sucursales)
            {
                sucursalPicker.Items.Add(sucursal);
            }


            if (citaActual != null)
            {
                nuevaCitaTitleLabel.Text = "Modificar Cita";
                placaVehiculoEntry.Text = citaActual.placaVehiculo;
                modoDePagoPicker.Title = citaActual.medioPago;

            }


            backButton = new Button
            {
                HeightRequest = 50,
                WidthRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Atras",
                BackgroundColor = Color.DeepPink

            };
            backButton.Clicked += BackButton_Clicked;

            modoDePagoPicker.SelectedIndexChanged += (sender, args) =>
            {
                modoDePagoPicker.Title = modoDePagoPicker.Items[modoDePagoPicker.SelectedIndex];

            };



            saveButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Guardar",

            };
            saveButton.Clicked += SaveButton_Clicked;

            modoDePagoPicker.SelectedIndexChanged += (sender, args) =>
            {
                modoDePagoPicker.Title = modoDePagoPicker.Items[modoDePagoPicker.SelectedIndex];

            };



            datePicker = new DatePicker
            {
                MinimumDate = DateTime.Now,
                MaximumDate = new DateTime(2022, 12, 31),
                Date = DateTime.Now,
            };

            timePicker = new TimePicker
            {

            };

            layout.BackgroundColor = Color.Azure;
            layout.Children.Add(nuevaCitaTitleLabel);
            layout.Children.Add(placaVehiculoEntry);
            layout.Children.Add(modoDePagoPicker);
            layout.Children.Add(tipoLavadoPicker);
            layout.Children.Add(sucursalPicker);
            Label fecha = new Label();
            fecha.Text = "Fecha";
            layout.Children.Add(fecha); 
            layout.Children.Add(datePicker);
            Label hora = new Label();
            hora.Text = "Hora";
            layout.Children.Add(hora);
            layout.Children.Add(timePicker);
            layout.Children.Add(saveButton);
            layout.Children.Add(backButton);
            Content = layout;
        }

        // Descripción: Permite acceder a la página anterior
        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            bool back = await DisplayAlert("AVISO", "Se perderán los datos modificados.", "Atras", "OK");
            if (!back)
            {
                await Navigation.PushAsync(new GestionCitaPage(currentUser));
            }
           
        }

        // Descripción: Permite guardar los cambios modificados en la base de datos. 
        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            // insertar a la base
            await DisplayAlert("AVISO", "Cita agendada exitosamente.", "OK");
            await Navigation.PushAsync(new GestionCitaPage(currentUser));
        }
    }
}