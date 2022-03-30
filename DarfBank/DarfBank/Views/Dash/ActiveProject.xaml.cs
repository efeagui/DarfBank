using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarfBank.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DarfBank.Views.Dash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActiveProject : ContentPage
    {
        public List<ProjectViewModel> projects { get; set; }
        public ActiveProject()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            projects = new List<ProjectViewModel>(ProjectModel.Get());
            cv.ItemsSource = projects;
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private void btnRecent_Clicked(object sender, EventArgs e)
        {
            ChangeButtonAppearance((Label)sender);
        }

        private void btnToday_Clicked(object sender, EventArgs e)
        {
            ChangeButtonAppearance((Label)sender);
        }

        private void ChangeButtonAppearance(Label btn)
        {
            if (btn.Text == "Recent")
            {
                ChangeButtonColor(btnRecent, true);
                ChangeButtonColor(btnToday, false);
                ChangeButtonColor(btnUpcoming, false);
            }
            else if (btn.Text == "Today")
            {
                ChangeButtonColor(btnRecent, false);
                ChangeButtonColor(btnToday, true);
                ChangeButtonColor(btnUpcoming, false);
            }
            else if (btn.Text == "Upcoming")
            {
                ChangeButtonColor(btnRecent, false);
                ChangeButtonColor(btnToday, false);
                ChangeButtonColor(btnUpcoming, true);
            }
        }

        private void ChangeButtonColor(Label btn, bool isSelected)
        {
            if (isSelected)
                btn.TextColor = Color.FromHex("#0C1F4B");
            else
                btn.TextColor = Color.DarkGray;
        }


    }
}