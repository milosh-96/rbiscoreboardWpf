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

namespace RBIScoreboard.Windows
{
    /// <summary>
    /// Interaction logic for EditTeam.xaml
    /// </summary>
    public partial class EditTeam : Window
    {
        public EditTeam()
        {
            InitializeComponent();
        }

        public void Save(object sender,RoutedEventArgs e)
        {
            if(TeamName.Text == String.Empty)
            {
                MessageBox.Show("Please enter team name!");
                TeamName.Text = "Team Name";
            }

            if (TeamName.Text == String.Empty)
            {
                MessageBox.Show("Please enter a valid URL!!");
                LogoUrl.Text = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7b/New_York_Mets.svg/1200px-New_York_Mets.svg.png";
            }

            this.Close();
        }
    }
}
