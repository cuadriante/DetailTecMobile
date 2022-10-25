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
    public partial class MisPuntosPage : ContentPage
    {

        Label puntosActualesLabel;
        Label puntosUtilizadosLabel;
        Button backButton;

        StackLayout layout = new StackLayout();
        public MisPuntosPage()
        {
            InitializeComponent();

            puntosActualesLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Puntos actuales: ",

            };

            puntosUtilizadosLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Puntos utilizadors: ",

            };

            backButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Back",

            };
            backButton.Clicked += BackButton_Clicked;


            layout.Children.Add(puntosActualesLabel);
            layout.Children.Add(puntosUtilizadosLabel);
            layout.Children.Add(backButton);
            Content = layout;

        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage());
        }
    }
}