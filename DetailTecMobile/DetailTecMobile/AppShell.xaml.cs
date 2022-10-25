﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DetailTecMobile;

namespace DetailTecMobile

{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : ContentPage
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ClienteEntryPage), typeof(ClienteEntryPage));
        }
    }
}