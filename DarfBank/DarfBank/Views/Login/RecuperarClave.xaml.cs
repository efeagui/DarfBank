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

namespace DarfBank.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecuperarClave : ContentPage
    {
        public RecuperarClave()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("idUsuario"))
            {
                var val = Application.Current.Properties["idUsuario"];
            }
        }

        private async void btnsalnvar_Clicked(object sender, EventArgs e)
        {
            if (txtidentidad.Text == "" || txtidentidad.Text == null)
            {
                await DisplayAlert("Error", "Complete el campo de identidad", "OK");
            }else if (txtemail.Text == "" || txtemail.Text == null)
            {
                await DisplayAlert("Error", "Complete el campo de correo electronico", "OK");
            }
            else
            {
                Loger Logir = new Loger
                {
                    correo = txtemail.Text,
                    idCliente = txtidentidad.Text
                };
                try
                {
                    using (HttpClient cliente = new HttpClient())
                    {
                        //Uri RequestUri = new Uri(DireccionesServidor.ListarLogin);
                        Uri RequestUri = new Uri("https://fernando-castillo-201910080192.000webhostapp.com/Darf_Back/Usuarios/getCredenciales.php");
                        var json = JsonConvert.SerializeObject(Logir);
                        var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await cliente.PostAsync(RequestUri, contentJSON);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            await DisplayAlert("Alerta", "Credenciales enviadas a su correo electronico", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Alerta", "Datos incorrectos ", "OK");
                        }
                    }
                }
                catch (Exception e2)
                {
                    await DisplayAlert("Alerta", "Datos incorrectos " + e2.Message, "OK");
                }
            }
        }
    }
}