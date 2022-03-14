using DarfBank.Models;
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
    public partial class MyTask : ContentPage
    {
        public MyTask()
        {
            InitializeComponent();
            listView.ItemsSource = new TrackActivityModel().GetTask();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
                listView.SelectedItem = null;
        }

        private void btnRecent_Clicked(object sender, EventArgs e)
        {
            ChangeButtonAppearance((Button)sender);
            listView.IsVisible = true;
            listView1.IsVisible = false;
            listView.ItemsSource = new TrackActivityModel().GetTask();
        }

        private void btnToday_Clicked(object sender, EventArgs e)
        {
            ChangeButtonAppearance((Button)sender);
            listView1.IsVisible = true;
            listView.IsVisible = false;
            listView1.ItemsSource = new TrackActivityModel().GetTask();
        }

        private void ChangeButtonAppearance(Button btn)
        {
            if (btn.Text == "S-Publicos")
            {
                ChangeButtonColor(btnRecent, true);
                ChangeButtonColor(btnToday, false);
                ChangeButtonColor(btnUpcoming, false);
            }
            else if (btn.Text == "S-Privados")
            {
                ChangeButtonColor(btnRecent, false);
                ChangeButtonColor(btnToday, true);
                ChangeButtonColor(btnUpcoming, false);
            }
            else if (btn.Text == "Todos los S")
            {
                ChangeButtonColor(btnRecent, false);
                ChangeButtonColor(btnToday, false);
                ChangeButtonColor(btnUpcoming, true);
            }
        }

        private void ChangeButtonColor(Button btn, bool isSelected)
        {
            if (isSelected)
            {
                btn.BackgroundColor = Color.FromHex("#0C1F4B");
                btn.TextColor = Color.White;
            }
            else
            {
                btn.BackgroundColor = Color.White;
                btn.TextColor = Color.FromHex("#0C1F4B");
            }
        }
    }
}