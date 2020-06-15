using RBIScoreboard.ViewModels;
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

namespace RBIScoreboard.Controls.AtBat
{
    /// <summary>
    /// Interaction logic for AtBat.xaml
    /// </summary>
    public partial class AtBat : UserControl
    {
        private MainViewModel mainViewModel = new MainViewModel();
        public AtBat()
        {
            InitializeComponent();
            this.Loaded += AtBat_Loaded;
        }

        private void AtBat_Loaded(object sender,RoutedEventArgs e)
        {
            mainViewModel = (MainViewModel)this.DataContext;
        }

      
    }
}
