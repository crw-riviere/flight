using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarSim.ViewModel
{
    public delegate void ShipDetectedHandler(ShipViewModel ship, EventArgs e);

    public class Sensor
    {
        public int SensorRadius { get; set; }

        public string XRange
        {
            get
            {
                return string.Format("{0} - {1}", this.CurrentPosition.X - this.SensorRadius, this.CurrentPosition.X + this.SensorRadius);
            }
        }

        public string YRange
        {
            get
            {
                return string.Format("{0} - {1}", this.CurrentPosition.Y - this.SensorRadius, this.CurrentPosition.Y + this.SensorRadius);
            }
        }

        public Position CurrentPosition { get; set; }

        public event ShipDetectedHandler ShipDetected;

        public Sensor(string ShipID, Position position)
        {
            this.CurrentPosition = position;
            SimViewModel.Time.Tick += (o, e) => this.ExecSensor();
        }

        public void RaiseShipDetected(ShipViewModel ship)
        {
            ShipDetectedHandler handler = this.ShipDetected;
            if (handler != null)
            {
                handler(ship, null);
            }
        }

        public void ExecSensor()
        {
            foreach (ShipViewModel bogey in ZoneViewModel.ShipCollection)
            {
                if (bogey.Radar != this)
                {
                    int yPos = this.CurrentPosition.Y + this.SensorRadius;
                    int yNeg = this.CurrentPosition.Y - this.SensorRadius;
                    int xPos = this.CurrentPosition.X + this.SensorRadius;
                    int xNeg = this.CurrentPosition.X - this.SensorRadius;

                    if ((yPos >= bogey.CurrentPosition.Y && bogey.CurrentPosition.Y >= yNeg) ||
                        (xPos >= bogey.CurrentPosition.X && bogey.CurrentPosition.X >= xNeg))
                    {
                        this.RaiseShipDetected(bogey);
                    }

                    //if (bogey.CurrentPosition.Y < this.CurrentPosition.Y + this.SensorRadius ||
                    //    bogey.CurrentPosition.Y < this.CurrentPosition.Y - this.SensorRadius ||
                    //    bogey.CurrentPosition.X < this.CurrentPosition.X + this.SensorRadius ||
                    //    bogey.CurrentPosition.X < this.CurrentPosition.X - this.SensorRadius)
                }
            }
        }
    }
}