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
    public partial class GestionClientePage : ContentPage
    {
        Button insertarClienteButton;
        Button modificarClienteButton;
        Button eliminarClienteButton;
        Button verClientesButton;
        Button backButton;

        StackLayout layout = new StackLayout();

        public GestionClientePage()
        {
            InitializeComponent();

            insertarClienteButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Insertar Cliente",

            };
            insertarClienteButton.Clicked += InsertarClienteButton_Clicked;


            modificarClienteButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Modificar Cliente",

            };
            modificarClienteButton.Clicked += ModificarClienteButton_Clicked;


            eliminarClienteButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Eliminar Cliente",

            };
            eliminarClienteButton.Clicked += EliminarClienteButton_Clicked;


            verClientesButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Visualizar Clientes",

            };
            verClientesButton.Clicked += VerClientesButton_Clicked;


            backButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Back",

            };
            backButton.Clicked += BackButton_Clicked;


            layout.Children.Add(insertarClienteButton);
            layout.Children.Add(modificarClienteButton);
            layout.Children.Add(eliminarClienteButton);
            layout.Children.Add(verClientesButton);
            layout.Children.Add(backButton);
            Content = layout;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage());
        }

        private async void InsertarClienteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GestionClientePage());
        }

        private async void ModificarClienteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GestionCitaPage());
        }

        private async void EliminarClienteButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisFacturasPage());
        }

        private async void VerClientesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisPuntosPage());
        }
    }
}