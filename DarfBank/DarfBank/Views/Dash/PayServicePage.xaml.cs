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
        public PayServicePage(int idServicio, int idCuenta, string Servicio, string numeroCuenta, string tipoServicio, string idCliente)
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
            if (!string.IsNullOrEmpty(PagoIngresado.Text))
            {
                var monto = double.Parse(totalPay.Text);
                var pago = double.Parse(PagoIngresado.Text);

                if (pago >= monto)
                {
                    var cambio = pago - monto;
                    
                    WebClient client = new WebClient();

                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("idTipoServicio", idTipoServicioPay.Text);
                    parametros.Add("idServicio", idServicioPay.Text);
                    parametros.Add("idCuenta", idCuentaPay.Text);
                    parametros.Add("valor", monto.ToString());
                    parametros.Add("idCliente", idClientePay.Text);

                    client.UploadValues("http://192.168.0.11/movil/servicePayment.php", "POST", parametros);

                    await DisplayAlert(null, "Pago Realizado, Su cambio es: " + cambio, "OK");
                    await Navigation.PushAsync(new Dashboard());
                }
                else
                {
                    await DisplayAlert("Error", "Pago No Realizado, Ingrese el monto correcto", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Ingrese un monto para realizar su pago", "OK");
            }
                
            
        }
    }
}