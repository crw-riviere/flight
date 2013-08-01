using RadarSim.Resource;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;

namespace RadarSim.ViewModel
{
    public class ZoneViewModel : BaseViewModel
    {
        public static ObservableCollection<ShipViewModel> ShipCollection { get; set; }

        public ZoneViewModel()
        {
            ShipViewModel a = ShipViewModel.GetShip();
            ShipViewModel b = ShipViewModel.GetShip();
            b.TargetShip = a;
            ShipCollection = new ObservableCollection<ShipViewModel>()
            {
                a,b
            };
        }
    }
}