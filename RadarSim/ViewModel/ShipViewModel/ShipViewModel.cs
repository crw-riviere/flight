using RadarSim.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RadarSim.ViewModel
{
    public partial class ShipViewModel : BaseViewModel
    {
        public string ShipID { get; set; }

        public Brush Colour { get; set; }

        public event EventHandler ShipFired;

        public Position CurrentPosition { get; set; }

        public ShipViewModel TargetShip { get; set; }

        public Direction CurrentDirection { get; set; }

        public Sensor Radar { get; set; }

        public int Speed { get; set; }

        public ShipViewModel(Position positon, Direction direction)
        {
            this.CurrentPosition = positon;
            this.CurrentDirection = direction;
            this.Radar = new Sensor(this.ShipID, this.CurrentPosition);
            this.Radar.SensorRadius = 10;
            this.Radar.ShipDetected += (ship, args) => this.OnBogeyDetected(ship);
            SimViewModel.Time.Tick += (o, e) => this.Move();
        }

        public void OnBogeyDetected(ShipViewModel bogey)
        {
            int x = 0;
        }

        public void ShipFire()
        {
            if (this.ShipFired != null)
            {
                EventHandler handler = this.ShipFired;
                handler(this, null);
            }
        }
    }
}