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
using System.Windows.Shapes;

namespace RBIScoreboard
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class OutputWindow : Window
    {
        private ViewModels.MainViewModel _viewModel { get; set; }
        public OutputWindow(ViewModels.MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _viewModel.Draw(HeaderRuns, AwayTeamRuns, HomeTeamRuns);

            this.DataContext = _viewModel;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Normal) {
                   MessageBox.Show("The output window works best if it's maximized or run in full screen mode. Thank you.");
            }
        }
    }
}
