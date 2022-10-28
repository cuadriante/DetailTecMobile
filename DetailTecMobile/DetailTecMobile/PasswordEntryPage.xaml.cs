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
    public partial class PasswordEntryPage : ContentPage
    {

        Button backButton;

        Entry oldPasswordEntry;

        Entry passwordEntry;

        Button confirmPasswordButton;

        Label passwordTitleLabel;

        StackLayout layout = new StackLayout();

        string currentUser;
        string currentParametro;
        public PasswordEntryPage(string user, string parametro)
        {
            currentUser = user;
            currentParametro = parametro;
            InitializeComponent();

            passwordTitleLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = $"Cambiar {currentParametro}",
                FontSize = 48

            };

            layout.Children.Add(passwordTitleLabel);

            backButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Atras",

            };
            backButton.Clicked += BackButton_Clicked;

            if (currentParametro == "Contraseña")
            {
                oldPasswordEntry = new Entry()
                {
                    //  HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Placeholder = $"{currentParametro} actual",
                    IsPassword = true,
                    MaxLength = 20,
                    ClearButtonVisibility = ClearButtonVisibility.WhileEditing
                };

                layout.Children.Add(oldPasswordEntry);
            }

           passwordEntry = new Entry()
            {
                //  HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = $"Nuevo/a {currentParametro}",
                IsPassword = true,
                MaxLength = 20,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing
            };


            confirmPasswordButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Guardar",

            };
            confirmPasswordButton.Clicked += ConfirmPasswordButton_Clicked;

            

            
            layout.Children.Add(passwordEntry);
            layout.Children.Add(confirmPasswordButton);
            layout.Children.Add(backButton);
            Content = layout;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GestionClientePage(currentUser));
        }

        private async void ConfirmPasswordButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("AVISO.", $"Cambio de {currentParametro} exitoso.", "OK");
            await Navigation.PushAsync(new GestionClientePage(currentUser));
        }
    }
}