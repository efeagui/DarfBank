using DarfBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DarfBank.Views.Tarjetas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TarejetaCredito : ContentPage
    {
        public TarejetaCredito()
        {
            InitializeComponent();
            listView.ItemsSource = new TrackActivityModel().Get();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
                listView.SelectedItem = null;
        }
    }
}