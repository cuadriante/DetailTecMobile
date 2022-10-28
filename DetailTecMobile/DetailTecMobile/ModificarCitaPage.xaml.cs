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
        public ModificarCitaPage(string user)
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
                IsPassword = true,
                MaxLength = 20,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing
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


            backButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Atras",

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

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            bool back = await DisplayAlert("AVISO", "Se perderán los datos modificados.", "Atras", "OK");
            if (!back)
            {
                await Navigation.PushAsync(new GestionCitaPage(currentUser));
            }
           
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            // insertar a la base
            await DisplayAlert("AVISO", "Cita agendada exitosamente.", "OK");
            await Navigation.PushAsync(new GestionCitaPage(currentUser));
        }
    }
}