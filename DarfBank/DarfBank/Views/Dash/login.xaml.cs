using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarfBank.Views.Dash;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            // await Navigation.PushAsync(new Dash.WelcomePage());
            await Navigation.PushAsync(new WelcomePage());
           // await Shell.Current.GoToAsync("WelcomePage");
        }
    }
}