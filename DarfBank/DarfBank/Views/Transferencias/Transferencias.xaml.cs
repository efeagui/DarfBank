using DarfBank.Views.Dash;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DarfBank.Views.Transferencias
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Transferencias : ContentPage
    {
        public Transferencias()
        {
            InitializeComponent();
        }

        private async void transferir_Clicked(object sender, EventArgs e)
        {
            Models.MovimientosBancarios.MovimientoBancario obj = new Models.MovimientosBancarios.MovimientoBancario
            {
                idTipoMovimiento = "Transferencia bancaria a mismo banco",
                fecha_movimiento = DateTime.UtcNow.ToString(),
                idCuenta = cuentaOrigen.Text,
                valor = cuentaDestino.Text,
                valorLps = cantidadTransferir.Text,
                concepto = descripcion.Text,
                fecha_hora = DateTime.UtcNow.ToString(),
                idCliente = Application.Current.Properties["idCliente"].ToString()
            };
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    Uri RequestUri = new Uri("https://fernando-castillo-201910080192.000webhostapp.com/Darf_Back/MovimientoBancario/tranferencia.php");
                    var json = JsonConvert.SerializeObject(obj);
                    var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await cliente.PostAsync(RequestUri, contentJSON);

                    if (response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Alerta", "Transferencia realizada exitosamente", "OK");
                        Task task = Navigation.PushAsync(new Dashboard(Application.Current.Properties["usuario"].ToString()));

                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo generar el pago", "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}