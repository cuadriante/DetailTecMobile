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


   
        StackLayout layout = new StackLayout();

        string currentUser;

        public GestionClientePage(string user)
        {
            InitializeComponent();

            currentUser = user;

            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente { id = "118460116", nombre = "adri", apellido1 = "calde", apellido2 = "ron", email = "adri@uwu.owo" },
              
            };


        }



        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage(currentUser));
        }


        private async void CambiarPasswordButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PasswordEntryPage(currentUser));
        }

        async void clienteListView_ClienteSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var cliente = e.SelectedItem as Cliente;
            await Navigation.PushAsync(new MenuPage(cliente.id));
        }

    }
}