using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBIScoreboard.Models
{
    public class Team : Abstractions.A_INotifyPropertyChanged
    {

        public Team()
        {

            // Assign event handler for propertychanged for each stat //
            foreach (Stat run in this.LinescoreRuns)
            {
                run.PropertyChanged += Run_Changed;
            }

            for (int i = 0; i< 9; i++)
            {
                this.Lineup.Add(new Player()
                {
                    Number = Faker.RandomNumber.Next(0,99),
                    Name = Faker.Name.FullName(Faker.NameFormats.Standard),
                    Age = Faker.RandomNumber.Next(17, 39)
                });
            }

            //Calculate number of run on the first launch//
            this.TotalRuns = this.LinescoreRuns.Sum<Stat>(run => run.Value);

        }


        private ObservableCollection<Player> lineup = new ObservableCollection<Player>();

        public ObservableCollection<Player> Lineup
        {
            get { return lineup; }
            set { lineup = value; }
        }



        private void Run_Changed(object sender, EventArgs e)
        {
            this.TotalRuns = this.LinescoreRuns.Sum<Stat>(run => run.Value);
        }


        private string logoUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7b/New_York_Mets.svg/1200px-New_York_Mets.svg.png";

        public string LogoURL
        {
            get { return logoUrl; }
            set { logoUrl = value;OnPropertyChanged(); }
        }


        private string name = "test";

        public string Name
        {
            get {
                if(name == String.Empty)
                {
                    return "Unnamed Team";
                }
                return name;
            }
            set { name = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Stat> linescoreRuns = new ObservableCollection<Stat>() {
            new Stat() {Value=0},
            new Stat() {Value=0},
            new Stat() {Value=0},
            new Stat() {Value=0},
            new Stat() {Value=0},
            new Stat() {Value=0},
            new Stat() {Value=0},
            new Stat() {Value=0},
            new Stat() {Value=0},
        };

        public ObservableCollection<Stat> LinescoreRuns
        {
            get { return linescoreRuns; }
            set { linescoreRuns = value; }
        }


        private Stat hits = new Stat();

        public Stat Hits
        {
            get { return hits; }
            set { hits = value;OnPropertyChanged(); }
        }

        private Stat errors = new Stat();

        public Stat Errors
        {
            get { return errors; }
            set { errors = value;OnPropertyChanged(); }
        }




        private int totalRuns;

        public int TotalRuns
        {
            get
            {
                return totalRuns;
            }
            set { totalRuns = value; OnPropertyChanged(); }
        }



        

    }
}
