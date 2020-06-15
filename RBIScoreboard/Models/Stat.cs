using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBIScoreboard.Models
{
    public class Stat : Abstractions.A_INotifyPropertyChanged
    {
        private int scoreValue;

        public int Value
        {
            get { return scoreValue; }
            set
            {
                scoreValue = value;
                OnPropertyChanged();
            }
            
        }

    }
}
