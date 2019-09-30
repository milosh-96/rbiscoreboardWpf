using RBIScoreboard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBIScoreboard.ViewModels
{
    class MainViewModel : Abstractions.A_INotifyPropertyChanged
    {
        private Team homeTeam = new Team() { Name="Washington Nationals",LogoURL= "https://tinyurl.com/y6sga29u" };

        public Team HomeTeam
        {
            get { return homeTeam; }
            set { homeTeam = value;OnPropertyChanged(); }
        }

        private Team awayTeam = new Team() { Name = "New York Mets", LogoURL = "https://tinyurl.com/kq5fnt9" };

        public Team AwayTeam
        {
            get { return awayTeam; }
            set { awayTeam = value;OnPropertyChanged(); }
        }









    }
}
