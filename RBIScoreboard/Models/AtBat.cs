using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBIScoreboard.Models
{
    public class AtBat : Abstractions.A_INotifyPropertyChanged
    {

		private int currentPlayerNumber;

		public int CurrentPlayerNumber
		{
			get { return currentPlayerNumber; }
			set { currentPlayerNumber = value;OnPropertyChanged(); }
		}


		private int outs = 0;

		public int Outs
		{
			get { return outs; }
			set { outs = value;OnPropertyChanged(); }
		}
		private int strikes = 0;

		public int Strikes
		{
			get { return strikes; }
			set { strikes = value;OnPropertyChanged(); }
		}

		private int balls = 0;

		public int Balls
		{
			get { return balls; }
			set { balls = value; OnPropertyChanged(); }
		}



	}
}
