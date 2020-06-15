using RBIScoreboard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace RBIScoreboard.ViewModels
{




    public class MainViewModel : Abstractions.A_INotifyPropertyChanged
    {

        public Commands.AtBat.SingleHitCommand singleHitCommand  { get; set; }
        public Commands.AtBat.DoubleHitCommand doubleHitCommand { get; set; }
        public Commands.AtBat.TripleHitCommand tripleHitCommand { get; set; }
        public Commands.AtBat.HomerunHitCommand homerunHitCommand { get; set; }

        public OutputWindow OutputWindow = null;


        public bool HomeRunEvent = false;
        public MainViewModel()
        {
            this.singleHitCommand = new Commands.AtBat.SingleHitCommand(this);
            this.doubleHitCommand = new Commands.AtBat.DoubleHitCommand(this);
            this.tripleHitCommand = new Commands.AtBat.TripleHitCommand(this);
            this.homerunHitCommand = new Commands.AtBat.HomerunHitCommand(this);
        }

        private AtBat currentAtBat = new AtBat();

        public AtBat CurrentAtBat
        {
            get { return currentAtBat; }
            set { currentAtBat = value; }
        }



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


        private Inning inning = new Inning();

        public Inning Inning
        {
            get { return inning; }
            set { inning = value;OnPropertyChanged(); }
        }




        //

       private void IncreaseHits()
        {
            var t = this.Inning.Part;

            switch (t)
            {
                case "Top":
                    this.AwayTeam.Hits.Value += 1;
                    if (AreBasesLoaded())
                    {
                        this.AwayTeam.LinescoreRuns[(this.Inning.Number - 1)].Value += 1;
                    }
                    break;
                case "Bottom":
                    this.HomeTeam.Hits.Value += 1;
                    if (AreBasesLoaded())
                    {
                        this.HomeTeam.LinescoreRuns[(this.Inning.Number - 1)].Value += 1;
                    }
                    break;
            }
        }

        private void ClearBases()
        {
            Inning.FirstBase = false;
            Inning.SecondBase = false;
            Inning.ThirdBase = false;
            Inning.HomeBase = false;
        }
        private void LoadBases()
        {
            Inning.FirstBase = true;
            Inning.SecondBase = true;
            Inning.ThirdBase = true;
        }
        private void LoadBases(bool homeRun)
        {
            Inning.FirstBase = true;
            Inning.SecondBase = true;
            Inning.ThirdBase = true;
            Inning.HomeBase = true;
        }


      


        public void SingleHit()
        {

            this.IncreaseHits();

            if (!this.Inning.FirstBase)
            {
                this.Inning.FirstBase = true;
            }
            else if (!this.Inning.SecondBase)
            {
                this.Inning.SecondBase = true;
            }
            else if (!this.Inning.ThirdBase)
            {
                this.Inning.ThirdBase = true;
            }
       
   }

        public void DoubleHit()
        {
            this.IncreaseHits();
            if(this.Inning.SecondBase == false)
            {
                this.Inning.SecondBase = true;
            }
        
        }


        // TODO - Method doesn't get called via Command! //
        public void TripleHit()
        {
            MessageBox.Show("AA");
            this.IncreaseHits();
            if (this.Inning.ThirdBase == false)
            {
                this.Inning.ThirdBase = true;
            }

        }
        // TODO //
        public void HomerunHit()
        {
            this.HomeRunEvent = true;
            this.IncreaseHits();

            switch (Inning.Part)
            {
                case "Top":
                    this.AwayTeam.LinescoreRuns[(inning.Number - 1)].Value += (NumberOfLoadedBases() + 1);
                    break;
                case "Bottom":
                    this.HomeTeam.LinescoreRuns[(inning.Number) - 1].Value += (NumberOfLoadedBases() + 1);
                    break;
            }

            Library.Animations.AnimateHomerun(this.Inning,200,4);
            //LoadBases(true);

            //await Task.Delay(1000);

            //ClearBases();

        }


        private int NumberOfLoadedBases()
        {
            int i = 0;

            if (this.Inning.FirstBase)
            {
                i++;
            }
            if (this.Inning.SecondBase)
            {
                i++;
            }
            if (this.Inning.ThirdBase)
            {
                i++;
            }

            return i;
        }

        private bool AreBasesLoaded()
        {
            if (
                (this.Inning.FirstBase) &&
                (this.Inning.SecondBase) &&
                (this.Inning.ThirdBase)
                )
            {
                return true;
            }

            return false;
        }




        public void Draw(StackPanel headerRuns,StackPanel awayTeamRuns,StackPanel homeTeamRuns,bool editable = false)
        {
            for (int i = 0; i < 9; i++)
            {
                headerRuns.Children.Add(
                    new TextBlock() { TextAlignment = TextAlignment.Center, MinWidth = editable ? 30 : 60, Text = (i + 1).ToString() }
                );
            }

            foreach (Stat run in this.AwayTeam.LinescoreRuns)
            {
                AddElement(awayTeamRuns, run,editable);
            }

            foreach (Stat run in this.HomeTeam.LinescoreRuns)
            {
                AddElement(homeTeamRuns, run,editable);
            }

        }

        private void AddElement(StackPanel stackPanel, Stat run, bool editable = false)
        {
            if (editable)
            {
                var element = new TextBox() { MinWidth = 30, HorizontalContentAlignment = HorizontalAlignment.Center };
                Binding binding = new Binding("Value");
                binding.Source = run;

                element.SetBinding(TextBox.TextProperty, binding);
                stackPanel.Children.Add(element);
            }
            else
            {
                var element = new TextBlock() { MinWidth = 60, TextAlignment = TextAlignment.Center };
                Binding binding = new Binding("Value");
                binding.Source = run;

                element.SetBinding(TextBlock.TextProperty, binding);
                stackPanel.Children.Add(element);
            }
          
        }



    }
}
