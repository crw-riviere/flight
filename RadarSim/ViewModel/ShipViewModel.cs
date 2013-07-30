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

        public Direction CurrentDirection { get; set; }

        private void GetNextPosition()
        {
            if (this.OutOfBounds())
            {
                this.GetNextDirection();
            }
            else
            {
                this.ApplyDirection(this.CurrentDirection);
            }
        }

        private void GetNextDirection()
        {
            Direction direction = this.CurrentDirection.GetOppositeDirection();
            if (direction != null)
            {
                this.ApplyDirection(direction);
            }
        }

        private void ApplyDirection(Direction direction)
        {
            int x = this.CurrentPosition.X + (int)direction.X;
            int y = this.CurrentPosition.Y + (int)direction.Y;
            this.CurrentPosition.O = direction.Orienation;

            this.CurrentPosition.X = x;
            this.CurrentPosition.Y = y;

            this.CurrentDirection = direction;
        }

        private bool OutOfBounds()
        {
            bool oob = false;

            if (this.CurrentPosition.X <= 0)
            {
                this.CurrentPosition.X = 0;
                oob = true;
            }

            if (this.CurrentPosition.X >= 500)
            {
                this.CurrentPosition.X = 500;
                oob = true;
            }

            if (this.CurrentPosition.Y <= 0)
            {
                this.CurrentPosition.Y = 0;
                oob = true;
            }

            if (this.CurrentPosition.Y >= 500)
            {
                this.CurrentPosition.Y = 500;
                oob = true;
            }

            return oob;
        }

        public void Move()
        {
            this.GetNextPosition();

            base.OnPropertyChanged(() => this.CurrentPosition);
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