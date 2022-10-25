using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailTecMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GestionCitaPage : ContentPage
    {
        Button insertarCitaButton;
        Button modificarCitaButton;
        Button eliminarCitaButton;
        Button verCitasButton;
        Button backButton;

        StackLayout layout = new StackLayout();

        public GestionCitaPage()
        {
            InitializeComponent();

            insertarCitaButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Insertar Cita",

            };
            insertarCitaButton.Clicked += InsertarCitaButton_Clicked;


            modificarCitaButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Modificar Cita",

            };
            modificarCitaButton.Clicked += ModificarCitaButton_Clicked;


            eliminarCitaButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Eliminar Cita",

            };
            eliminarCitaButton.Clicked += EliminarCitaButton_Clicked;


            verCitasButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Visualizar Citas",

            };
            verCitasButton.Clicked += VerCitasButton_Clicked;


            backButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Back",

            };
            backButton.Clicked += BackButton_Clicked;


            layout.Children.Add(insertarCitaButton);
            layout.Children.Add(modificarCitaButton);
            layout.Children.Add(eliminarCitaButton);
            layout.Children.Add(verCitasButton);
            layout.Children.Add(backButton);
            Content = layout;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage());
        }

        private async void InsertarCitaButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GestionCitaPage());
        }

        private async void ModificarCitaButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GestionCitaPage());
        }

        private async void EliminarCitaButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisFacturasPage());
        }

        private async void VerCitasButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisPuntosPage());
        }
    }
}