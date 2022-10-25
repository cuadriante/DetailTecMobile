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
                Placeholder = "Username",
                MaxLength = 20,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing
                 
            };

            passwordEntry = new   Entry()
            {
              //  HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = "Password",
                IsPassword = true,
                MaxLength = 20,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing
            };

            logInButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Log In",
            
            };
            logInButton.Clicked += LogInButton_Clicked;
            
            layout.Children.Add(titleLabel);    
            layout.Children.Add(userEntry);
            layout.Children.Add(passwordEntry);
            layout.Children.Add(logInButton);
            Content = layout;


        }

        private void LogInButton_Clicked(object sender, EventArgs e)
        {
            user = userEntry.Text;
            password = passwordEntry.Text;
            bool valid = true; //bindear con base de datos 
            if (valid)
            {
                DisplayAlert("Log In Successful!", "yei.", "OK");
            } else
            {
                DisplayAlert("Log In Unsuccessful", "User or password incorrect.", "OK");
            };
                
        }
    }

}
