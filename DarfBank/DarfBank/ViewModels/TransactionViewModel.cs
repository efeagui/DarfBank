using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DarfBank.ViewModels
{
    public class TransactionViewModel
    {
        public ImageSource Img { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
    }
}
