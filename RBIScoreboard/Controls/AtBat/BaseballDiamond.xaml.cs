using System;
using System.Collections.Generic;
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
using RBIScoreboard.ViewModels;

namespace RBIScoreboard.Controls.AtBat
{
    /// <summary>
    /// Interaction logic for BaseballDiamond.xaml
    /// </summary>
    public partial class BaseballDiamond : UserControl
    {
        public MainViewModel mainViewModel = new MainViewModel();
        public BaseballDiamond()
        {
            InitializeComponent();
        }

        private void FillBase(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            //nađi bazu po tagu
            bool selectedBase = (bool)mainViewModel.Inning.GetType().GetProperty(rect.Tag.ToString()).GetValue(mainViewModel.Inning, null);

            if(selectedBase == false)
            {
                selectedBase = true;
            }
            else
            {
                selectedBase = false;
            }



            // oboji bazu 

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            mainViewModel = (MainViewModel)this.DataContext;
        
          
        }
    }
}
