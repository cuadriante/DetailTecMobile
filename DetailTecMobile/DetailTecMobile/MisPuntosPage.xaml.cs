using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetailTecMobile.Services;
using DetailTecMobile.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailTecMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisPuntosPage : ContentPage
    {

        Label puntosTitleLabel;
        Label puntosActualesLabel;
        Label puntosUtilizadosLabel;
        Label numeroPuntosActualesLabel;
        Label numeroPuntosUtilizadosLabel;
        Button backButton;

        string numeroPuntosUtilizados;
        string numeroPuntosActuales;
        string currentUser;

        StackLayout layout = new StackLayout();
        public MisPuntosPage(string user)
        {
            currentUser = user; 
            InitializeComponent();

            Console.WriteLine(user);

            

            puntosTitleLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Mis Puntos",
                FontSize = 48

            };
            puntosActualesLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 22,
                Text = "Puntos disponibles"

            };

            puntosUtilizadosLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 22,
                Text = "Puntos utilizados"

            };

            numeroPuntosActualesLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 50,
                Text = numeroPuntosActuales

            };

            numeroPuntosUtilizadosLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 50,
                Text = numeroPuntosUtilizados

            };

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

            layout.BackgroundColor = Color.Azure;
            layout.Children.Add(puntosTitleLabel);
            layout.Children.Add(puntosActualesLabel);
            layout.Children.Add(numeroPuntosActualesLabel);
            layout.Children.Add(puntosUtilizadosLabel);
            layout.Children.Add(numeroPuntosUtilizadosLabel);
            layout.Children.Add(backButton);
            Content = layout;

            

        }


        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage(currentUser));
        }
    }
}