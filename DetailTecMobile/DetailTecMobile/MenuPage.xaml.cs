﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace DetailTecMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {

        Button gestionClientesButton;
        Button gestionCitasButton;
        Button misFacturasButton;
        Button misPuntosButton;
        Button backButton;
        Label usernameLabel;

        StackLayout layout = new StackLayout();

        string currentUser;


        public MenuPage(string user)
        {
            currentUser = user;
            InitializeComponent();

            usernameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = user,
            };

            gestionClientesButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Mi Perfil",

            };
            gestionClientesButton.Clicked += GestionClientesButton_Clicked;


            gestionCitasButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Mis Citas",

            };
            gestionCitasButton.Clicked += GestionCitasButton_Clicked;


            misFacturasButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Mis Facturas",

            };
            misFacturasButton.Clicked += MisFacturasButton_Clicked;

            misPuntosButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Mis Puntos",

            };
            misPuntosButton.Clicked += MisPuntosButton_Clicked;


            backButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = "Atras",

            };
            backButton.Clicked += BackButton_Clicked;

            layout.Children.Add(usernameLabel);
            layout.Children.Add(gestionClientesButton);
            layout.Children.Add(gestionCitasButton);
            layout.Children.Add(misFacturasButton);
            layout.Children.Add(misPuntosButton);
            layout.Children.Add(backButton);
            Content = layout;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GreetPage());
        }

        private async void GestionClientesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GestionClientePage(currentUser));
        }

        private async void GestionCitasButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GestionCitaPage(currentUser));
        }

        private async void MisFacturasButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisFacturasPage(currentUser));
        }

        private async void MisPuntosButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MisPuntosPage(currentUser));
        }
    }
}