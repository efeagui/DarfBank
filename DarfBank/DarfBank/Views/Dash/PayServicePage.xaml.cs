using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DarfBank.Views.Dash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PayServicePage : ContentPage
    {
        public PayServicePage(int idServicio, string Servicio, string numeroCuenta, string tipoServicio, string idCliente)
        {
            InitializeComponent();

            idServicioPay.Text = idServicio.ToString();
            idTipoServicioPay.Text = tipoServicio;
            ServicioPay.Text = Servicio;
            numero_cuentaPay.Text = numeroCuenta;

            Random random = new Random();
            int total = random.Next(150, 10000);

            totalPayLps.Text = "Lps. " + total.ToString();
            totalPay.Text = total.ToString();
        }
    }
}