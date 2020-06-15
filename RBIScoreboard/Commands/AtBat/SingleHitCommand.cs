using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RBIScoreboard.Commands.AtBat
{

    public class SingleHitCommand : ICommand
    {

        public ViewModels.MainViewModel viewModel { get; set; }

        public SingleHitCommand(ViewModels.MainViewModel viewModel)
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
            this.viewModel.SingleHit();
        }
    }
}
