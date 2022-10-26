using DetailTecMobile.Models;
using DetailTecMobile.Services;
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
    public partial class GreetPage : ContentPage
    {

        Button logInButton;

        StackLayout layout = new StackLayout();

        Label titleLabel;

        Label userLabel;

        Entry userEntry;

        Entry passwordEntry;

        Label passwordLabel;

        private string user;
        private string password;


        public GreetPage()
        {
            InitializeComponent();

            titleLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "DetailTEC",
                FontSize = 48

            };

            userEntry = new Entry()
            {
                //HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = "Usuario",
                MaxLength = 20,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing
                 
            };

            passwordEntry = new   Entry()
            {
              //  HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = "Contraseña",
                IsPassword = true,
                MaxLength = 20,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing
            };

            logInButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Iniciar Sesión",
            
            };
            logInButton.Clicked += LogInButton_Clicked;
            
            layout.Children.Add(titleLabel);    
            layout.Children.Add(userEntry);
            layout.Children.Add(passwordEntry);
            layout.Children.Add(logInButton);
            Content = layout;


        }

        private async void LogInButton_Clicked(object sender, EventArgs e)
        {
            user = userEntry.Text;
            password = passwordEntry.Text;
            bool valid = true; //bindear con base de datos 
            if (valid)
            {
                await Navigation.PushAsync(new MenuPage(user));
            } else
            {
                await DisplayAlert("Log In Unsuccessful", "User or password incorrect.", "OK");
            };
                
        }
    }

}
