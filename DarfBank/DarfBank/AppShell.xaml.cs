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
            Routing.RegisterRoute(nameof(Services), typeof(Services));
            Routing.RegisterRoute(nameof(HistoryCard), typeof(HistoryCard));
            Routing.RegisterRoute(nameof(NewTransaction), typeof(NewTransaction));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login");
        }
    }
}