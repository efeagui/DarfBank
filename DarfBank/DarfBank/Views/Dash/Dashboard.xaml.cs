using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DarfBank.Views.Tarjetas;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DarfBank.Views.Dash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            getcuentas();
        }

        private async void getcuentas()
        {
            Models.Cuentas.Cuenta cuenta = new Models.Cuentas.Cuenta
            {
                idCliente = Application.Current.Properties["idCliente"].ToString()
            };
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    //Uri RequestUri = new Uri(DireccionesServidor.ListarLogin);
                    Uri RequestUri = new Uri("https://fernando-castillo-201910080192.000webhostapp.com/Darf_Back/Cuentas/ListaCuentas.php");
                    var json = JsonConvert.SerializeObject(cuenta);
                    var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await cliente.PostAsync(RequestUri, contentJSON);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        Models.Cuentas.lstCuentas lst = new Models.Cuentas.lstCuentas();
                        var contenido = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<Models.Cuentas.lstCuentas>(contenido);
                        lstCuentas.ItemsSource = lst.cuentas;
                    }
                }
            }
            catch (Exception e2)
            {
                await DisplayAlert("Error", e2.Message, "OK");
            }
        }

        private async void BtnCheckActivity_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("login");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MyTask");
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("TarejetaCredito");
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("HistoryCard");
        }

        private async void btn2_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Services");
        }

        private void lstCuentas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void btn4_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WelcomePage());
        }

        private async void btn1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Transferencias.Transferencias());
        }

        private async void btn3_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Transferencias.Transferencias());
        }
    }
}