using System;
using System.Collections.Generic;
using System.Text;

namespace DarfBank.ViewModels
{
    public class TransactionModel
    {
        public List<TransactionViewModel> Get()
        {
            List<TransactionViewModel> list = new List<TransactionViewModel>();
            list.Add(new TransactionViewModel { Name = "Envie", Description = "Carlos josue", Amount = "Lps. 120", Img = "https://img.icons8.com/cotton/2x/transfer-money.png" });
            list.Add(new TransactionViewModel { Name = "Recibi ", Description = "Josue Matute", Amount = "Lps. 200", Img = "https://img.icons8.com/ultraviolet/50/000000/money-bag.png" });
            list.Add(new TransactionViewModel { Name = "Pague", Description = "Tigo Plan", Amount = "Lps. 582", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            list.Add(new TransactionViewModel { Name = "Envie", Description = "743456532", Amount = "Lps. 785", Img = "https://img.icons8.com/cotton/2x/transfer-money.png" });
            list.Add(new TransactionViewModel { Name = "Recibi", Description = "Karla Pavon", Amount = "Lps. 587", Img = "https://img.icons8.com/ultraviolet/50/000000/money-bag.png" });
            list.Add(new TransactionViewModel { Name = "Pague", Description = "Hondutel", Amount = "Lps. 785", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            list.Add(new TransactionViewModel { Name = "Pague", Description = "Enee Luz", Amount = "Lps. 258", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            return list;
        }
    }
}
