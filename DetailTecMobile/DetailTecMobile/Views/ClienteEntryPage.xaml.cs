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
    public partial class ClienteEntryPage : ContentPage
    {

        public string ItemId
        {
            set
            {
                LoadCliente(value);
            }
        }
        public ClienteEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new ClienteModel();
        }

        async void LoadCliente(string itemId)
        {
            try
            {
                string id = itemId.ToString();
                // Retrieve the note and set it as the BindingContext of the page.
                ClienteModel cliente = await App.Db.Obtener(id);
                BindingContext = cliente;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var cliente = (ClienteModel)BindingContext;
            if (!string.IsNullOrWhiteSpace(cliente.nombre))
            {
                await App.Db.Modificar(cliente);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var cliente = (ClienteModel)BindingContext;
            await App.Db.Eliminar(cliente);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }




    }
}