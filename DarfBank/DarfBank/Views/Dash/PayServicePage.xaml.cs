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
    public partial class PayServicePage : ContentPage
    {
        public PayServicePage(string idServicio, string idCuenta, string Servicio, string numeroCuenta, string tipoServicio, string idCliente)
        {
            InitializeComponent();

            idServicioPay.Text = idServicio.ToString();
            idCuentaPay.Text = idCuenta.ToString();
            idTipoServicioPay.Text = tipoServicio;
            ServicioPay.Text = Servicio;
            numero_cuentaPay.Text = numeroCuenta;
            idClientePay.Text = idCliente;

            Random random = new Random();
            int total = random.Next(150, 10000);

            totalPayLps.Text = "Lps. " + total.ToString();
            totalPay.Text = total.ToString();
        }

        private async void payService_Clicked(object sender, EventArgs e)
        {
            Models.MovimientosBancarios.MovimientoBancario obj = new Models.MovimientosBancarios.MovimientoBancario
            {
                idTipoMovimiento = ServicioPay.Text,
                fecha_movimiento = DateTime.UtcNow.ToString(),
                idCuenta = numero_cuentaPay.Text,
                valor = "N/A",
                valorLps = PagoIngresado.Text,
                concepto = ServicioPay.Text,
                fecha_hora = DateTime.UtcNow.ToString(),
                idCliente = Application.Current.Properties["idCliente"].ToString()
            };
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    Uri RequestUri = new Uri("https://fernando-castillo-201910080192.000webhostapp.com/Darf_Back/MovimientoBancario/CrearMovimientoBancario.php");
                    var json = JsonConvert.SerializeObject(obj);
                    var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await cliente.PostAsync(RequestUri, contentJSON);

                    if (response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Alerta", "Pago realizado exitosamente", "OK");
                        Task task = Navigation.PushAsync(new Dashboard());

                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo generar el pago", "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error",  ex.Message, "OK");
            }                
            
        }
    }
}