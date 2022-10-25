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

    
    public partial class MisFacturasPage : ContentPage
    {
        Button backButton;

        Label facturasTitleLabel;

        StackLayout layout = new StackLayout();
        public MisFacturasPage()
        {
            InitializeComponent();

            facturasTitleLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Mis Facturas",
                FontSize = 48

            };


            backButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Atras",

            };
            backButton.Clicked += BackButton_Clicked;

            layout.Children.Add(facturasTitleLabel);
            layout.Children.Add(backButton);
            Content = layout;

        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage());
        }
    }
}