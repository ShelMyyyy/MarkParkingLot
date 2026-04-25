using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Main.Common.ViewModels
{
    public class BaseViewModel:BindableBase
    {
		private int _id;

		public int ID
		{
			get => _id;
			set => SetProperty(ref _id, value);
		}

	}
}
