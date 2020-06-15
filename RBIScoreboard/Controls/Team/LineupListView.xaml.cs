using RBIScoreboard.ViewModels;
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

namespace RBIScoreboard.Controls.Team
{
    /// <summary>
    /// Interaction logic for LineupListView.xaml
    /// </summary>
    public partial class LineupListView : UserControl
    {


        private MainViewModel mainViewModel = new MainViewModel();

        public ObservableCollection<Models.Player> Lineup
        {
            get { return (ObservableCollection<Models.Player>)GetValue(LineupProperty); }
            set { SetValue(LineupProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Lineup.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LineupProperty =
            DependencyProperty.Register("Lineup", typeof(ObservableCollection<Models.Player>), typeof(LineupListView), new PropertyMetadata(new ObservableCollection<Models.Player>()));




        public LineupListView()
        {
            InitializeComponent();
            this.Loaded += LineupListView_Loaded;
        }

        private void LineupListView_Loaded(object sender, RoutedEventArgs e)
        {
            mainViewModel = (MainViewModel)this.DataContext;
        }

    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            foreach(Models.Player item in listView.Items)
            {
                item.IsSelected = false;
            }

            Models.Player player = (Models.Player) listView.SelectedItem;
            this.mainViewModel.CurrentAtBat.CurrentPlayerNumber = player.Number;
            this.mainViewModel.OutputWindow.Event.Text = String.Format("{0} {1}", player.Number, player.Name);
            player.IsSelected = true;

        }
    }
}
