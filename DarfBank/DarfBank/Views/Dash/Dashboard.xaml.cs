using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarfBank.Views.Tarjetas;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DarfBank.Views.Dash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private async void BtnCheckActivity_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("login");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MyTask");
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("TarejetaCredito");
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("HistoryCard");
        }

        private async void btn2_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MyTask");
        }
    }
}