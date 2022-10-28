using DetailTecMobile.Models;
using DetailTecMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Diagnostics;

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

            Login login = new Login
            {
                email = userEntry.Text,
                password = passwordEntry.Text,
                tipoUsuario = "Cliente"

            };

            Uri requestUri = new Uri("http://10.0.2.2:5064/login/verify");

            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(requestUri, contentJson);


            bool valid = false; //bindear con base de datos 

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseLogin>(data);

                await Navigation.PushAsync(new MenuPage(result.ClientID));
            }
            else
            {
                await DisplayAlert("Log In Unsuccessful", "User or password incorrect.", "OK");
            }
                
        }
    }

}
