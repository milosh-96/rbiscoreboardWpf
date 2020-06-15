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
            //OutputWindow outputWindow = new OutputWindow(mainViewModel);
            //outputWindow.Show();
            mainViewModel.Draw(HeaderRuns,AwayTeamRuns,HomeTeamRuns,true);
            this.DataContext = mainViewModel;

          

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

        private void InningPart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            string selectedItem = (string) ((ComboBoxItem) comboBox.SelectedItem).Content;
            this.mainViewModel.Inning.Part = selectedItem;
        }

        private void RunOutput_Click(object sender, RoutedEventArgs e)
        {
            OutputWindow outputWindow = new OutputWindow( mainViewModel);
            this.mainViewModel.OutputWindow = outputWindow;
            outputWindow.Show();
        }
    }
}
