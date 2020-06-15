using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RBIScoreboard.Commands.AtBat
{
    public class DoubleHitCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ViewModels.MainViewModel viewModel { get; set; }
        public DoubleHitCommand(ViewModels.MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.viewModel.DoubleHit();
        }
    }
}
