using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DarfBank.Models
{
    public class ProjectViewModel
    {
        public ImageSource Img { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Color StatusColor { get; set; }
        public string DeadLine { get; set; }
        public string TaskLeft { get; set; }
        public double Progress { get; set; }
    }
    public class ProjectModel
    {

        public static IEnumerable<ProjectViewModel> Get()
        {
            List<ProjectViewModel> projectList = new List<ProjectViewModel>();
            projectList.Add(new ProjectViewModel
            {
                Img = "https://assets.asana.biz/m/49dc10400a0dc519/original/article-project-planning-project-brief-2x.jpg",
                DeadLine = "20-01-2022",
                Name = "Information management System",
                Progress = 0.9,
                Status = "In Progress",
                StatusColor = Color.Green,
                TaskLeft = "1 Task Left"
            });

            projectList.Add(new ProjectViewModel
            {
                Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR87NgyOY98HKM-OgWXnZv9vFqA4N1pyVDLhw",
                DeadLine = "2-01-2022",
                Name = "Online Classes",
                Progress = 0.8,
                Status = "In Progress",
                StatusColor = Color.Orange,
                TaskLeft = "12 Task Left"
            });
            projectList.Add(new ProjectViewModel
            {
                Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSox3gVtgFJZkMyfvH2V1QLbvxsCkGHg_f8ig",
                DeadLine = "20-01-2022",
                Name = "Job Portal System",
                Progress = 0.2,
                Status = "In Progress",
                StatusColor = Color.Red,
                TaskLeft = "45 Task Left"
            });
            return projectList;
        }

    }
}
