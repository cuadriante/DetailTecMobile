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

    // Descripción: Página para la modificación de un dato especifico de un cliente según el usuario seleccionado
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

        // Descripción: Inicialización de página para la modificación de un parámetro de un usuario en la base de datos
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
                WidthRequest = 100,
                HeightRequest = 50,
                BackgroundColor = Color.DeepPink,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Atras",

            };
            backButton.Clicked += BackButton_Clicked;

            
           passwordEntry = new Entry()
            {
                //  HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = $"Nuevo/a {currentParametro}",
                MaxLength = 20,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing
            };

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
                passwordEntry.IsPassword = true;
            }


            confirmPasswordButton = new Button
            {
                HeightRequest = 50,
                WidthRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Guardar",

            };
            confirmPasswordButton.Clicked += ConfirmPasswordButton_Clicked;



            layout.BackgroundColor = Color.Azure;
            layout.Children.Add(passwordEntry);
            layout.Children.Add(confirmPasswordButton);
            layout.Children.Add(backButton);
            Content = layout;
        }


        // Descripción: Permite viajar a la página anterior
        private async void BackButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new GestionClientePage(currentUser));
        }


        // Descripción: Guarda los cambios al parámetro en la base de datos. 
        private async void ConfirmPasswordButton_Clicked(object sender, EventArgs e)
        {
            if (passwordEntry.Text != null)
            {
                await DisplayAlert("AVISO", $"Cambio de {currentParametro} exitoso.", "OK");
                await Navigation.PushAsync(new GestionClientePage(currentUser));
            } else
            {
                await DisplayAlert("ERROR", $"Cambio fallido, {currentParametro} no puede ser nulo.", "OK");
            }
                
        }   
    }
}