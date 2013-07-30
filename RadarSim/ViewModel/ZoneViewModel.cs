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
        public ObservableCollection<ShipViewModel> ShipCollection { get; set; }

        public ZoneViewModel()
        {
            this.ShipCollection = new ObservableCollection<ShipViewModel>()
            {
                ShipViewModel.GetShip(),
                ShipViewModel.GetShip()
            };

            this.Tick();
        }

        public void Tick()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += (o, e) => { this.MoveShips(); };
            timer.Start();
        }

        public void MoveShips()
        {
            foreach (ShipViewModel ship in this.ShipCollection)
            {
                ship.Move();
                //ship.ShipFire();
            }
        }
    }
}