using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DarfBank.Models
{
    public class TaskViewModel
    {
        public string TimeLeft { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double ProgressValue { get; set; }
        public string Progress { get; set; }
        public string Status { get; set; }
    }
    public class TrackActivityViewModel
    {
        public string Time { get; set; }
        public string Comment { get; set; }
        public string cash { get; set; }
        public ImageSource Img { get; set; }
    }
    public class TrackActivityModel
    {
        public List<TaskViewModel> GetTask()
        {
            List<TaskViewModel> list = new List<TaskViewModel>();
            list.Add(new TaskViewModel { Description = "hola data is benign information that does not contain any useful data, but serves to reserve space where real data is nominally present. Dummy data can be used as a placeholder for both testing and operational purposes.", Name = "Enee", ProgressValue = 0.5, Progress = "50%", Status = "In Progress", TimeLeft = "2 Days left" });
            list.Add(new TaskViewModel { Description = "dummy data is benign information that does not contain any useful data, but serves to reserve space where real data is nominally present. Dummy data can be used as a placeholder for both testing and operational purposes.", Name = "Sanaa", ProgressValue = 0.8, Progress = "80%", Status = "In Progress", TimeLeft = "4 Days left" });
            list.Add(new TaskViewModel { Description = "dummy data is benign information that does not contain any useful data, but serves to reserve space where real data is nominally present. Dummy data can be used as a placeholder for both testing and operational purposes.", Name = "Hondutel Telefonia", ProgressValue = 0.9, Progress = "90%", Status = "In Progress", TimeLeft = "1 week left" });
            list.Add(new TaskViewModel { Description = "dummy data is benign information that does not contain any useful data, but serves to reserve space where real data is nominally present. Dummy data can be used as a placeholder for both testing and operational purposes.", Name = "Hondutel Internet", ProgressValue = 0.4, Progress = "40%", Status = "In Progress", TimeLeft = "2 week left" });
            //list.Add(new TaskViewModel { Description = "dummy data is benign information that does not contain any useful data, but serves to reserve space where real data is nominally present. Dummy data can be used as a placeholder for both testing and operational purposes.", Name = "Login Page Design", ProgressValue = 0.2, Progress = "20%", Status = "In Progress", TimeLeft = "1 week left" });
            //list.Add(new TaskViewModel { Description = "dummy data is benign information that does not contain any useful data, but serves to reserve space where real data is nominally present. Dummy data can be used as a placeholder for both testing and operational purposes.", Name = "Budget Calculation", ProgressValue = 1.0, Progress = "100%", Status = "Completed", TimeLeft = "Done" });
           // list.Add(new TaskViewModel { Description = "dummy data is benign information that does not contain any useful data, but serves to reserve space where real data is nominally present. Dummy data can be used as a placeholder for both testing and operational purposes.", Name = "New Bug on Budget", ProgressValue = 0.6, Progress = "60%", Status = "In Progress", TimeLeft = "1 week left" });
          //  list.Add(new TaskViewModel { Description = "dummy data is benign information that does not contain any useful data, but serves to reserve space where real data is nominally present. Dummy data can be used as a placeholder for both testing and operational purposes.", Name = "Add New Item Page", ProgressValue = 0.1, Progress = "10%", Status = "In Progress", TimeLeft = "1 week left" });
          //  list.Add(new TaskViewModel { Description = "dummy data is benign information that does not contain any useful data, but serves to reserve space where real data is nominally present. Dummy data can be used as a placeholder for both testing and operational purposes.", Name = "Delete existing item", ProgressValue = 0.3, Progress = "30%", Status = "In Progress", TimeLeft = "1 week left" });
            return list;
        }
        public List<TrackActivityViewModel> Get()
        {
            List<TrackActivityViewModel> list = new List<TrackActivityViewModel>();
            list.Add(new TrackActivityViewModel { Time = "10-12-2012 11:00 am", Comment = "Farmacia el Ahorro", cash = "Lps.890.00", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            list.Add(new TrackActivityViewModel { Time = "10-12-2012 11:00 am", Comment = "Super Mercado la colonia", cash = "Lps.890.00", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            list.Add(new TrackActivityViewModel { Time = "10-12-2012 11:00 am", Comment = "Matricula Uth", cash = "Lps.890.00", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            list.Add(new TrackActivityViewModel { Time = "10-12-2012 11:00 am", Comment = "Tiendas Dinaf", cash = "Lps.890.00", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            list.Add(new TrackActivityViewModel { Time = "10-12-2012 11:00 am", Comment = "Amazon KFK", cash = "Lps.890.00", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            list.Add(new TrackActivityViewModel { Time = "10-12-2012 11:00 am", Comment = "Ebay - ecommer", cash = "Lps.890.00", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            list.Add(new TrackActivityViewModel { Time = "10-12-2012 11:00 am", Comment = "Inversiones Dummor", cash = "Lps.890.00", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            list.Add(new TrackActivityViewModel { Time = "10-12-2012 11:00 am", Comment = "Reposteria OHM", cash = "Lps.890.00", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            list.Add(new TrackActivityViewModel { Time = "10-12-2012 11:00 am", Comment = "Larash company", cash = "Lps.890.00", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            list.Add(new TrackActivityViewModel { Time = "10-12-2012 11:00 am", Comment = "Tigo-SuperRecarga", cash = "Lps.890.00", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            list.Add(new TrackActivityViewModel { Time = "10-12-2012 11:00 am", Comment = "Tigo Plan", cash = "Lps.890.00", Img = "https://img.icons8.com/ultraviolet/50/000000/card-in-use.png" });
            return list;
        }
    }
}
