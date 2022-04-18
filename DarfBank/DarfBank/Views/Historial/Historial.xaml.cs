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

namespace DarfBank.Views.Historial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Historial : ContentPage
    {
        public Historial(string numeroCuenta)
        {
            InitializeComponent();
            buscarHistorial(numeroCuenta);
        }

        private async void buscarHistorial(string numeroCuenta)
        {
            Models.MovimientosBancarios.MovimientoBancario cuenta = new Models.MovimientosBancarios.MovimientoBancario
            {
                idCliente = Application.Current.Properties["idCliente"].ToString(),
                idCuenta = numeroCuenta
            };
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    //Uri RequestUri = new Uri(DireccionesServidor.ListarLogin);
                    Uri RequestUri = new Uri("https://fernando-castillo-201910080192.000webhostapp.com/Darf_Back/MovimientoBancario/ListaMovimientoBancario.php");
                    var json = JsonConvert.SerializeObject(cuenta);
                    var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await cliente.PostAsync(RequestUri, contentJSON);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {

                        Models.MovimientosBancarios.lstMovimientosBancarios lst = new Models.MovimientosBancarios.lstMovimientosBancarios();
                        var contenido = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<Models.MovimientosBancarios.lstMovimientosBancarios>(contenido);
                        lstCuentas.ItemsSource = lst.MovimientoBancario;
                    }
                }
            }
            catch (Exception e2)
            {
                await DisplayAlert("Error", e2.Message, "OK");
            }
        }

        private void lstCuentas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private void btnNew_Clicked(object sender, EventArgs e)
        {

        }
    }
}