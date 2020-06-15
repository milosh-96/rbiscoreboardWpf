using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBIScoreboard.Models
{
    public class Inning : Abstractions.A_INotifyPropertyChanged
    {
        private int number = 1;

        public int Number
        {
            get { return number; }
            set
            {
                if (value == 0)
                {
                    number = 1;
                }
                else
                {
                    number = value;
                }
                OnPropertyChanged();
            }
        }



        // 0 = Top 1 = Bottom //
        private string part = "Top";

        public string Part
        {
            get { return part; }
            set { part = value;OnPropertyChanged(); }
        }



        private bool firstBase = false;

        public bool FirstBase
        {
            get { return firstBase; }
            set { firstBase = value;OnPropertyChanged(); }
        }

        private bool secondBase = false;

        public bool SecondBase
        {
            get { return secondBase; }
            set { secondBase = value; OnPropertyChanged(); }
        }

        private bool thirdBase = false;

        public bool ThirdBase
        {
            get { return thirdBase; }
            set { thirdBase = value; OnPropertyChanged(); }
        }

        private bool homeBase;

        public bool HomeBase
        {
            get { return homeBase; }
            set { homeBase = value;OnPropertyChanged(); }
        }



    }


}
