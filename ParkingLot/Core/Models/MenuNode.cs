using ParkingLot.Main.Common.ViewModels;
using Prism.Common;
using System.Collections.ObjectModel;

namespace ParkingLot.Models
{
    public class MenuNode: BaseViewModel
    {

        private string menuHeader;
        public string MenuHeader
        {
            get { return menuHeader; }
            set { SetProperty(ref menuHeader, value); }
        }

        public string TargetView { get; set; }
        public string MenuIcon { get; set; }
        public int? Index { get; set; }
        public int? MenuType { get; set; }
        public int State { get; set; }
        public ObservableCollection<MenuNode>? Children { get; set; }
    }
}
