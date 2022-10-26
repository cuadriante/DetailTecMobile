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
        public PasswordEntryPage(string user)
        {
            currentUser = user; 
            InitializeComponent();

            passwordTitleLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Cambiar contraseña",
                FontSize = 48

            };

            backButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Atras",

            };
            backButton.Clicked += BackButton_Clicked;

            oldPasswordEntry = new Entry()
            {
                //  HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = "Contraseña actual",
                IsPassword = true,
                MaxLength = 20,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing
            };


            passwordEntry = new Entry()
            {
                //  HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = "Contraseña nueva",
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

            layout.Children.Add(passwordTitleLabel);
            layout.Children.Add(oldPasswordEntry);
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
            await DisplayAlert("CAMBIO DE CONTRASEÑA EXITOSO.", "Utilice su nueva cotraseña para iniciar sesión.", "OK");
            await Navigation.PushAsync(new GestionClientePage(currentUser));
        }
    }
}