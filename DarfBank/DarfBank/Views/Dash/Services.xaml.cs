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

            Models.Services.Servicio obj = new Models.Services.Servicio
            {
                idTipoServicio = "Servicio Publico"
            };
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    //Uri RequestUri = new Uri(DireccionesServidor.ListarLogin);
                    Uri RequestUri = new Uri("https://fernando-castillo-201910080192.000webhostapp.com/Darf_Back/Servicios/ListaServicio.php");
                    var json = JsonConvert.SerializeObject(obj);
                    var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await cliente.PostAsync(RequestUri, contentJSON);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        Models.Services.lstServicios lst = new Models.Services.lstServicios();
                        var contenido = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<Models.Services.lstServicios>(contenido);
                        listViewServices.ItemsSource = lst.Servicios;
                    }
                }
            }
            catch (Exception e2)
            {
                await DisplayAlert("Error", e2.Message, "OK");
            }
        }

        private async void btnSSPrivate_Clicked(object sender, EventArgs e)
        {
            ChangeButtonAppearance((Button)sender);

            Models.Services.Servicio obj = new Models.Services.Servicio
            {
                idTipoServicio = "Servicio Privado"
            };
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    //Uri RequestUri = new Uri(DireccionesServidor.ListarLogin);
                    Uri RequestUri = new Uri("https://fernando-castillo-201910080192.000webhostapp.com/Darf_Back/Servicios/ListaServicio.php");
                    var json = JsonConvert.SerializeObject(obj);
                    var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await cliente.PostAsync(RequestUri, contentJSON);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        Models.Services.lstServicios lst = new Models.Services.lstServicios();
                        var contenido = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<Models.Services.lstServicios> (contenido);
                        listViewServices.ItemsSource = lst.Servicios;
                    }
                }
            }
            catch (Exception e2)
            {
                await DisplayAlert("Error", e2.Message, "OK");
            }
        }

        private async void btnSSDonation_Clicked(object sender, EventArgs e)
        {
            ChangeButtonAppearance((Button)sender);

            Models.Services.Servicio obj = new Models.Services.Servicio
            {
                idTipoServicio = "Donacion"
            };
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    //Uri RequestUri = new Uri(DireccionesServidor.ListarLogin);
                    Uri RequestUri = new Uri("https://fernando-castillo-201910080192.000webhostapp.com/Darf_Back/Servicios/ListaServicio.php");
                    var json = JsonConvert.SerializeObject(obj);
                    var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await cliente.PostAsync(RequestUri, contentJSON);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        Models.Services.lstServicios lst = new Models.Services.lstServicios();
                        var contenido = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<Models.Services.lstServicios>(contenido);
                        listViewServices.ItemsSource = lst.Servicios;
                    }
                }
            }
            catch (Exception e2)
            {
                await DisplayAlert("Error", e2.Message, "OK");
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
            var details = e.Item as Models.Services.Servicio;
            await Navigation.PushAsync(new PayServicePage(details.idServicio, "", details.servicio, "", details.idTipoServicio, Application.Current.Properties["idCliente"].ToString()));
        }
    }
}