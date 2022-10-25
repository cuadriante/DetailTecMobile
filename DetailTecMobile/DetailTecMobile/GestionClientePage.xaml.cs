using DetailTecMobile.Models;
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

        Label clienteTitleLabel;
        Button cambiarPasswordButton;
        Button backButton;

        Label idLabel;
        Label nombreLabel;
        Label apellido1Label;
        Label apellido2Label;
        Label emailLabel;

        string id;
        string nombre;
        string apellido1;
        string apellido2;
        string email;
     
        StackLayout layout = new StackLayout();

        public GestionClientePage()
        {
            InitializeComponent();

            string id = "118460116";
            string nombre = "adri";
            string apellido1 = "calde";
            string apellido2 = "ron";
            string email = "adri.com";

            clienteTitleLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Mi perfil",
                FontSize = 48

            };

            idLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "ID: " + id,
                FontSize = 22

            };

            nombreLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "NOMBRE: " + nombre,
                FontSize = 22

            };

            apellido1Label = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "PRIMER APELLIDO: " + apellido1,
                FontSize = 22

            };

            apellido2Label = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "SEGUNDO APELLIDO: " + apellido2,
                FontSize = 22

            };

            emailLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "EMAIL: " + email,
                FontSize = 22

            };


            cambiarPasswordButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Cambiar Contraseña",

            };
            cambiarPasswordButton.Clicked += CambiarPasswordButton_Clicked;


            backButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Atras",

            };
            backButton.Clicked += BackButton_Clicked;

            layout.Children.Add(clienteTitleLabel);
            layout.Children.Add(idLabel);
            layout.Children.Add(nombreLabel);
            layout.Children.Add(apellido1Label);
            layout.Children.Add(apellido2Label);
            layout.Children.Add(emailLabel);
            layout.Children.Add(cambiarPasswordButton);
            layout.Children.Add(backButton);
            Content = layout;
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


        private async void CambiarPasswordButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PasswordEntryPage());
        }

    }
}