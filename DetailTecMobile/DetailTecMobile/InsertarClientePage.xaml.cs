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
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class InsertarClientePage : ContentPage
    {
        public string Id
        {
            set
            {
                LoadNote(value);
            }
        }

        public InsertarClientePage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new Models.Cliente();
        }

        async void LoadNote(string d)
        {
            try
            {
                string id = d;
                // Retrieve the note and set it as the BindingContext of the page.
                Cliente cliente = await App.Database.Obtener(id);
                BindingContext = cliente;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var cliente = (Cliente)BindingContext;
            if (!string.IsNullOrWhiteSpace(cliente.id))
            {
                await App.Database.Insertar(cliente);
            }

            // Navigate backwards
            Navigation.PushAsync(new GestionClientePage());
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var cliente = (Cliente)BindingContext;
            await App.Database.Eliminar(cliente);

            // Navigate backwards
            Navigation.PushAsync(new GestionClientePage());
        }
    }
}