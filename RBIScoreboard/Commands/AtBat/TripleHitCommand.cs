using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBIScoreboard.Commands.AtBat
{
    public class TripleHitCommand
    {

        public ViewModels.MainViewModel viewModel { get; set; }

        public TripleHitCommand(ViewModels.MainViewModel viewModel)
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
            this.viewModel.TripleHit();
        }
    }
}
