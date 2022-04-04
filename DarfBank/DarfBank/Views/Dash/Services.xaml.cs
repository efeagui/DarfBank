using DarfBank.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DarfBank.Views.Dash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Services : ContentPage
    {
        public Services()
        {
            InitializeComponent();
        }

        private async void btnSSPublic_Clicked(object sender, EventArgs e)
        {
            ChangeButtonAppearance((Button)sender);

            var request = new HttpRequestMessage();

            request.RequestUri = new Uri("http://192.168.0.11/movil/listServicios.php?idTipoServicio=1");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            
            var client = new HttpClient();
            
            HttpResponseMessage response = await client.SendAsync(request);
            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Models.Services>>(content);
                listViewServices.ItemsSource = resultado;
            }
        }

        private async void btnSSPrivate_Clicked(object sender, EventArgs e)
        {
            ChangeButtonAppearance((Button)sender);

            var request = new HttpRequestMessage();

            request.RequestUri = new Uri("http://192.168.0.11/movil/listServicios.php?idTipoServicio=2");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Models.Services>>(content);
                listViewServices.ItemsSource = resultado;
            }
        }

        private async void btnSSDonation_Clicked(object sender, EventArgs e)
        {
            ChangeButtonAppearance((Button)sender);

            var request = new HttpRequestMessage();

            request.RequestUri = new Uri("http://192.168.0.11/movil/listServicios.php?idTipoServicio=3");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Models.Services>>(content);
                listViewServices.ItemsSource = resultado;
            }
        }

        private void ChangeButtonAppearance(Button btn)
        {
            if (btn.Text == "S-Publicos")
            {
                ChangeButtonColor(btnSPublic, true);
                ChangeButtonColor(btnSPrivate, false);
                ChangeButtonColor(btnSDonate, false);
            }
            else if (btn.Text == "S-Privados")
            {
                ChangeButtonColor(btnSPublic, false);
                ChangeButtonColor(btnSPrivate, true);
                ChangeButtonColor(btnSDonate, false);
            }
            else if (btn.Text == "Donaciones")
            {
                ChangeButtonColor(btnSPublic, false);
                ChangeButtonColor(btnSPrivate, false);
                ChangeButtonColor(btnSDonate, true);
            }
        }

        private void ChangeButtonColor(Button btn, bool isSelected)
        {
            if (isSelected)
            {
                btn.BackgroundColor = Color.FromHex("#0C1F4B");
                btn.TextColor = Color.White;
            }
            else
            {
                btn.BackgroundColor = Color.White;
                btn.TextColor = Color.FromHex("#0C1F4B");
            }
        }

        private async void listViewServices_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Models.Services;
            await Navigation.PushAsync(new PayServicePage(details.idServicio, details.idCuenta, details.Servicio, details.numero_cuenta, details.idTipoServicio, details.idCliente));
        }
    }
}