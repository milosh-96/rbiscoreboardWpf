using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RBIScoreboard.Commands.AtBat
{
    public class HomerunHitCommand : ICommand
    {
        public ViewModels.MainViewModel viewModel { get; set; }

        public HomerunHitCommand(ViewModels.MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(this.viewModel.OutputWindow != null)
            {
                this.viewModel.OutputWindow.Event.Text = "HOMERUN!!";
            }
            this.viewModel.HomerunHit();
        }
    }
}
