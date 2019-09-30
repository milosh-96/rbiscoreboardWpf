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


      
    }
}
