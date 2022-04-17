using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using DarfBank.Views.Dash;
using DarfBank.Models;
using DarfBank.Setting;
using System.Threading;

namespace DarfBank.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class NewUser : ContentPage
    {
        CancellationTokenSource cts;
        string base64Val = "";
        public NewUser()
        {
            InitializeComponent();
        }
        private async void btnfotocap_Clicked(object sender, EventArgs e)
        {
            var tomarfoto = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "miApp",
                Name = "Image.jpg"
            });
            if (tomarfoto != null)
            {
                imagen.Source = ImageSource.FromStream(() => { return tomarfoto.GetStream(); });
            }
            Byte[] imagenByte = null;
            using (var stream = new MemoryStream())
            {
                tomarfoto.GetStream().CopyTo(stream);
                tomarfoto.Dispose();
                imagenByte = stream.ToArray();
                base64Val = Convert.ToBase64String(imagenByte);
            }
        }
        private async void btnCapturarFoto_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            try
            {
                Stream streama = null;
                var file = await CrossMedia.Current.PickPhotoAsync().ConfigureAwait(true);
                if (file == null)
                    return;
                streama = file.GetStream();
                imagen.Source = ImageSource.FromStream(() => streama);
                Byte[] imagenByte = null;
                using (var stream = new MemoryStream())
                {
                    file.GetStream().CopyTo(stream);
                    file.Dispose();
                    imagenByte = stream.ToArray();
                    base64Val = Convert.ToBase64String(imagenByte);
                }
            }
            catch
            {

            }
        }
        private async void btnsalnvar_Clicked(object sender, EventArgs e)
        {
            try 
            {
                if (String.IsNullOrWhiteSpace(base64Val) == true)
                {
                    await DisplayAlert("Porfavor", "Tomese o cargue una selfie", "Ok");
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(txtusuario.Text) == true)
                    {
                        await DisplayAlert("Porfavor", "Ingrese un usuario", "Ok");
                    }
                    else if (String.IsNullOrWhiteSpace(txtcontrasenia.Text) == true)
                    {
                        await DisplayAlert("Porfavor", "Ingrese una contrasenia", "Ok");
                    }
                    else if (String.IsNullOrWhiteSpace(txtemail.Text) == true)
                    {
                        await DisplayAlert("Porfavor", "Ingrese su Correo electronico", "Ok");
                    }
                    else if (String.IsNullOrWhiteSpace(txtidentidad.Text) == true)
                    {
                        await DisplayAlert("Porfavor", "Ingrese su identidad", "Ok");
                    }
                    else if (String.IsNullOrWhiteSpace(txtrol.Text) == true)
                    {
                        await DisplayAlert("Porfavor", "Ingrese el numero 1", "Ok");
                    }
                    else if (String.IsNullOrWhiteSpace(txtestado.Text) == true)
                    {
                        await DisplayAlert("Porfavor", "Ingrese el numero 1", "Ok");
                    }
                    else
                    {
                        Loger logers = new Loger
                        {
                            usuario = txtusuario.Text,
                            contrasenia = txtcontrasenia.Text,
                            correo = txtemail.Text,
                            activo = txtestado.Text,
                            idCliente = txtidentidad.Text,
                            idRol = txtrol.Text,
                            imagen = "data:image/png;base64," + base64Val
                        };
                        try
                        {
                            using (HttpClient cliente = new HttpClient())
                            {
                                Uri RequestUri = new Uri("https://fernando-castillo-201910080192.000webhostapp.com/Darf_Back/Usuarios/CrearUsuario.php");
                                var json = JsonConvert.SerializeObject(logers);
                                var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                                var response = await cliente.PostAsync(RequestUri, contentJSON);

                                if (response.IsSuccessStatusCode)
                                {
                                    await DisplayAlert("Cliente", "Regitrado Exitosamente", "OK");
                                    txtusuario.Text = txtcontrasenia.Text = txtemail.Text = txtestado.Text = txtidentidad.Text = txtidentidad.Text = txtrol.Text = base64Val = String.Empty;
                                    imagen.Source = "perfil.jpg";
                                    Task task = Navigation.PushAsync(new login());

                                }
                                else
                                {
                                    await DisplayAlert("Error", "Estamos en mantenimiento", "Ok");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            await DisplayAlert("Cliente", "No se Puedo registrar " + ex.Message, "OK");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        protected override void OnDisappearing()
        {
            if (cts != null && !cts.IsCancellationRequested)
                cts.Cancel();
            base.OnDisappearing();
        }
    }
}