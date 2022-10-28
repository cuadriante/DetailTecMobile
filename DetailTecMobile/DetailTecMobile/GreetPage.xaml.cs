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


     // Descripción: Inicializa la página para inicio de sesión a la página web

        public GreetPage()
        {
            InitializeComponent();

            var image = new Image { Source = "detailtec.png" };
           
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
                HeightRequest = 50,
                WidthRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Iniciar Sesión",
            
            };
            logInButton.Clicked += LogInButton_Clicked;

            layout.BackgroundColor = Color.Azure;
            layout.Children.Add(image);
            //layout.Children.Add(titleLabel);    
            layout.Children.Add(userEntry);
            layout.Children.Add(passwordEntry);
            layout.Children.Add(logInButton);
            Content = layout;


        }

        // Descripción: Al presionar el botón, verifica las credenciales del usuario con la base de datos 

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


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseLogin>(data);


                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("http://10.0.2.2:5064/cliente/get/"+result.ClientID);
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
                var client2 = new HttpClient();
                HttpResponseMessage response2 = await client2.SendAsync(request);

                if (response2.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string data2 = await response2.Content.ReadAsStringAsync();
                    Console.WriteLine(data2);
                    var response3 = JsonConvert.DeserializeObject<ClientResponse>(data2);

                    Cliente cliente = new Cliente
                    {
                        id = response3.client.id,
                        nombre= response3.client.nombre,
                        apellido1= response3.client.apellido1,
                        apellido2= response3.client.apellido2,
                        email= response3.client.email,
                        password = "",
                        total = response3.client.total,
                        utilizados = response3.client.utilizados,
                        actuales = response3.client.actuales
                        
                    };

                    await App.Database.Insertar(cliente);
                    
                }
                var clienteForName = await App.Database.ObtenerC(result.ClientID);


                var requestT = new HttpRequestMessage();
                requestT.RequestUri = new Uri("http://10.0.2.2:5064/trabajador/get_all");
                requestT.Method = HttpMethod.Get;
                requestT.Headers.Add("Accept", "application/json");
                var clientT = new HttpClient();
                HttpResponseMessage responseT = await clientT.SendAsync(requestT);

                if (responseT.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string data2 = await responseT.Content.ReadAsStringAsync();
                    Console.WriteLine(data2);
                    var response3 = JsonConvert.DeserializeObject<TrabajadorResponse>(data2);
                    Console.WriteLine(response3.status);
                    Console.WriteLine(response3.employees.Count);


                    List<Trabajador>trabajadorList = new List<Trabajador>();

                    for (int i = 0; i < response3.employees.Count; i++)
                    {
                        trabajadorList.Add(new Trabajador()
                        {
                            id = response3.employees[i].id

                        });

                        await App.Database.Insertar(trabajadorList[i]);
                         
                    }
                    

                }

                var requestS = new HttpRequestMessage();
                requestS.RequestUri = new Uri("http://10.0.2.2:5064/sucursal/get_all");
                requestS.Method = HttpMethod.Get;
                requestS.Headers.Add("Accept", "application/json");
                var clientS = new HttpClient();
                HttpResponseMessage responseS = await clientS.SendAsync(requestS);

                if (responseS.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string data2 = await responseS.Content.ReadAsStringAsync();
                    Console.WriteLine(data2);
                    var response3 = JsonConvert.DeserializeObject<SucursalResponse>(data2);
                    Console.WriteLine(response3.status);
                    Console.WriteLine(response3.branches.Count);


                    List<Sucursal> sucList = new List<Sucursal>();

                    for (int i = 0; i < response3.branches.Count; i++)
                    {
                        sucList.Add(new Sucursal()
                        {
                            id = response3.branches[i].id,
                            name = response3.branches[i].nombre

                        });

                        await App.Database.Insertar(sucList[i]);

                    }


                }

                var requestL = new HttpRequestMessage();
                requestL.RequestUri = new Uri("http://10.0.2.2:5064/lavado/get_all");
                requestL.Method = HttpMethod.Get;
                requestL.Headers.Add("Accept", "application/json");
                var clientL = new HttpClient();
                HttpResponseMessage responseL = await clientL.SendAsync(requestL);

                if (responseL.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string data2 = await responseL.Content.ReadAsStringAsync();
                    Console.WriteLine(data2);
                    var response3 = JsonConvert.DeserializeObject<LavadoResponse>(data2);
                    Console.WriteLine(response3.status);
                    Console.WriteLine(response3.washingTypes.Count);


                    List<Lavado> lavadoList = new List<Lavado>();

                    for (int i = 0; i < response3.washingTypes.Count; i++)
                    {
                        lavadoList.Add(new Lavado()
                        {
                            id = response3.washingTypes[i].id,
                            name = response3.washingTypes[i].nombre

                        });

                        await App.Database.Insertar(lavadoList[i]);

                    } 


                }

                var requestC = new HttpRequestMessage();
                requestC.RequestUri = new Uri("http://10.0.2.2:5064/cita/get_all");
                requestC.Method = HttpMethod.Get;
                requestC.Headers.Add("Accept", "application/json");
                var clientC = new HttpClient();
                HttpResponseMessage responseC = await clientC.SendAsync(requestC);

                if (responseC.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string data2 = await responseC.Content.ReadAsStringAsync();
                    Console.WriteLine(data2);
                    var response3 = JsonConvert.DeserializeObject<CitaResponse>(data2);
                    Console.WriteLine(response3.status);
                    Console.WriteLine(response3.appointments.Count);


                    List<Cita> citaList = new List<Cita>();

                    for (int i = 0; i < response3.appointments.Count; i++)
                    {
                        citaList.Add(new Cita()
                        {
                            id = response3.appointments[i].id,
                            cedulaCliente = response3.appointments[i].cedulaCliente,
                            placaVehiculo = response3.appointments[i].placaVehiculo,
                            IDSucursal = response3.appointments[i].IDSucursal,
                            tipoLavado = response3.appointments[i].tipoLavado,
                            fecha = response3.appointments[i].fecha,
                            hora = response3.appointments[i].hora.ToString(),
                            medioPago = response3.appointments[i].medioPago,
                            generada = 0
                            //idEmpleados = response3.appointments[i].idEmpleados


                        });

                        await App.Database.Insertar(citaList[i]);

                    }
                }


                await Navigation.PushAsync(new MenuPage(clienteForName.nombre));

            }
            else
            {
                await DisplayAlert("AVISO", "Usuario o contraseña incorrecta.", "OK");
                
            };
                
        }
    }

}
