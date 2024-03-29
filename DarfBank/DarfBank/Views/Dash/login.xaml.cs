﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarfBank.Views.Dash;
using Xamarin.Forms;
using DarfBank.Models;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;
using DarfBank.Setting;
using System.Net;
using DarfBank.Views.Login;

namespace DarfBank.Views.Dash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Loger Logir = new Loger
            {
                usuario = txtUser.Text,
                contrasenia = txtPass.Text
            };
            try
            {
                 using (HttpClient cliente = new HttpClient())
                 {
                     //Uri RequestUri = new Uri(DireccionesServidor.ListarLogin);
                     Uri RequestUri = new Uri("https://fernando-castillo-201910080192.000webhostapp.com/Darf_Back/Usuarios/getUsuario.php");
                     var json = JsonConvert.SerializeObject(Logir);
                     var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                     var response = await cliente.PostAsync(RequestUri, contentJSON);

                    if (response.StatusCode==HttpStatusCode.OK)
                     {
                        
                        User.lstUsuario user = new User.lstUsuario();
                        var contenido = response.Content.ReadAsStringAsync().Result;
                        user = JsonConvert.DeserializeObject<User.lstUsuario>(contenido);
                        Application.Current.Properties["idUsuario"] = user.usuarios[0].idUsuario;
                        Application.Current.Properties["usuario"] = user.usuarios[0].usuario;
                        Application.Current.Properties["correo"] = user.usuarios[0].correo;
                        Application.Current.Properties["idCliente"] = user.usuarios[0].idCliente;
                        Application.Current.Properties["imagen"] = user.usuarios[0].imagen;
                        await Navigation.PushAsync(new Dashboard(user.usuarios[0].usuario.ToString()));
                    }
                    else
                    {
                        await DisplayAlert("Usuario o Contrasena ", "Incorrecta ", "OK");
                    }
                 }
             }
             catch (Exception e2)
             {
                 await DisplayAlert("Usuario o Contrasena ", "Incorrecta " + e2.Message, "OK");
             }
        }

        private async void NewUser_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NewUser");
        }

        private async void Button_Clicked_Recuperar(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("RecuperarClave");
        }
    }
}