using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RBIScoreboard.Models
{
    public class Player : Abstractions.A_INotifyPropertyChanged
    {

        public Uri PortraitPicture { get; set; } = new Uri("https://randomuser.me/api/portraits/men/14.jpg");

        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }


        private string name = "";

        public string Name
        {
            get { return name; }
            set { name = value;OnPropertyChanged(); }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value;OnPropertyChanged(); }
        }

        private string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        private bool isSelected = false;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value;OnPropertyChanged(); }
        }




    }
}
