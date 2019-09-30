using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RBIScoreboard.Models;

namespace RBIScoreboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModels.MainViewModel mainViewModel = new ViewModels.MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            Draw();
            this.DataContext = mainViewModel;

          

        }

        

        private void Draw()
        {
            for(int i = 0;i < 9;i++)
            {
                HeaderRuns.Children.Add(
                    new TextBlock() { TextAlignment=TextAlignment.Center, Width = 30, Text = (i + 1).ToString() }
                );
            }

            foreach(Stat run in mainViewModel.AwayTeam.LinescoreRuns)
            {
                AddElement(AwayTeamRuns, run);
            }

            foreach (Stat run in mainViewModel.HomeTeam.LinescoreRuns)
            {
                AddElement(HomeTeamRuns, run);
            }

        }

        private void AddElement(StackPanel stackPanel,Stat run)
        {
            var element = new TextBox() { Width = 30, HorizontalContentAlignment = HorizontalAlignment.Center };
            Binding binding = new Binding("Value");
            binding.Source = run;

            element.SetBinding(TextBox.TextProperty, binding);
            stackPanel.Children.Add(element);
        }

        private void EditTeam_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            Windows.EditTeam editTeam = new Windows.EditTeam();

            switch(menuItem.Name)
            {
                case "EditAwayTeam":
                    editTeam.DataContext = mainViewModel.AwayTeam;
                    break;
                case "EditHomeTeam":
                    editTeam.DataContext = mainViewModel.HomeTeam;
                    break;
            }

            editTeam.ShowDialog();
        }
    }
}
