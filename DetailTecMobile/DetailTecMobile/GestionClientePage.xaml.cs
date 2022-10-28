using DetailTecMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DetailTecMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

   
    // Descripción: Visualización de datos del usuario cliente actual y posible modificación. 
    public partial class GestionClientePage : ContentPage
    {

        ObservableCollection<Models.ClientInfo> info;

        StackLayout layout = new StackLayout();

        string currentUser;

        string nombre;
        string apellido1;
        string apellido2;
        string email;
        List<string> telefonos;
        List<string> direcciones;
        string contrasena;

        // Inicialización de la página y obtención de los datos a partir de la base de datos. 
        public GestionClientePage(string user)
        {
            InitializeComponent();

            currentUser = user;

            nombre = "Adriana";
            apellido1 = "Calderón";
            apellido2 = "Barboza";
            email = "adriana@sinapsis.ws";
            telefonos = new List<string>();
            telefonos.Add("62446155");
            telefonos.Add("87059045");
            direcciones = new List<string>();
            direcciones.Add("Tres Rios");
            direcciones.Add("Tres Rios Centro");
            contrasena = "-";

            info = new ObservableCollection<Models.ClientInfo>
             {
             new Models.ClientInfo{Text = $"NOMBRE: \n{nombre}", Descripcion="nombre", dato = nombre},
             new Models.ClientInfo{Text = $"PRIMER APELLIDO: \n{apellido1}", Descripcion="PRIMER APELLIDO", dato = apellido1},
             new Models.ClientInfo{Text = $"SEGUNDO APELLIDO: \n{apellido2}", Descripcion="SEGUNDO APELLIDO", dato = apellido2},
             new Models.ClientInfo{Text = $"EMAIL: \n{email}", Descripcion="EMAIL", dato = email},
             new Models.ClientInfo { Text = $"TELEFONO: \n1. {telefonos[0]}", Descripcion="TELEFONO", dato = telefonos[0] }

        };

            if (telefonos.Count > 0)
            {
                for (int i = 1; i < telefonos.Count; i++)
                {
                    var item = new Models.ClientInfo { Text = $"{i + 1}. {telefonos[i]}", Descripcion = "TELEFONO", dato = telefonos[i] };
                    info.Add(item);
                }
            }

            info.Add(new Models.ClientInfo { Text = $"DIRECCION: \n1. {direcciones[0]}", Descripcion = "DIRECCION" , dato = direcciones[0] });
            
            if (direcciones.Count > 0)
            {
                for (int i = 1; i < telefonos.Count; i++)
                {
                    var item = new Models.ClientInfo { Text = $"{i + 1}. {direcciones[i]}" , Descripcion = "DIRECCION", dato = direcciones[i] };

                    info.Add(item);
                }
            }

            info.Add(new Models.ClientInfo { Text = $"CONTRASEÑA", Descripcion = "CONTRASEÑA", dato = contrasena });


            clienteCollectionView.ItemsSource = info;


        }



        // Descripción: Regresa a la página anterior
        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage(currentUser));
        }

        // Descripción: Pop up con el detalle del dato seleccionado y posibilidad de modificación
        async void clienteCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var itemSelected = e.CurrentSelection[0] as Models.ClientInfo;
            if (itemSelected != null)
            {
                bool mod = await DisplayAlert(itemSelected.Descripcion, itemSelected.dato, "Modificar", "Ok");
                if (mod)
                {
                    await Navigation.PushAsync(new PasswordEntryPage(currentUser, itemSelected.Descripcion));
                }
            }
                
        }

    }
}