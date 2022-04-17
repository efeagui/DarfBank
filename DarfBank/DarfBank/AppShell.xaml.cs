using System;
using System.Collections.Generic;
using DarfBank.Views;
using DarfBank.Views.Dash;
using DarfBank.Views.Login;
using DarfBank.Views.Tarjetas;

using Xamarin.Forms;

namespace DarfBank
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(login), typeof(login));
            Routing.RegisterRoute(nameof(Dashboard), typeof(Dashboard));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(TarejetaCredito), typeof(TarejetaCredito));
            Routing.RegisterRoute(nameof(MyTask), typeof(MyTask));
            Routing.RegisterRoute(nameof(HistoryCard), typeof(HistoryCard));
            Routing.RegisterRoute(nameof(NewTransaction), typeof(NewTransaction));
            Routing.RegisterRoute(nameof(NewUser), typeof(NewUser));
            Routing.RegisterRoute(nameof(CreateNewUser), typeof(CreateNewUser)); 
                Routing.RegisterRoute(nameof(RecuperarClave), typeof(RecuperarClave));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login");
        }
    }
}