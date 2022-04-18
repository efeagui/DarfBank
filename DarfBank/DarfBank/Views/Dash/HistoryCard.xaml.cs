using DarfBank.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DarfBank.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryCard : ContentPage
    {
        public HistoryCard()
        {
            InitializeComponent();
            listView.ItemsSource = new TransactionModel().Get();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            dt.Focus();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                listView.SelectedItem = null;
            }
        }

        private void dt_DateSelected(object sender, DateChangedEventArgs e)
        {
            lblDate.Text = dt.Date.ToString("dd MMM yyyy");
        }
        private async void btnNew_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewTransaction());
        }
    }
}