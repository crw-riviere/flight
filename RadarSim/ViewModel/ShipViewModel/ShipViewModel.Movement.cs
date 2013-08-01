using RadarSim.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarSim.ViewModel
{
    public partial class ShipViewModel
    {
        private void GetNextDirection()
        {
            Direction direction = this.CurrentDirection.GetOppositeDirection();
            if (direction != null)
            {
                this.ApplyMovement(direction);
            }
        }

        private void GetNextPosition()
        {
            if (this.OutOfBounds())
            {
                this.GetNextDirection();
            }
            else
            {
                this.ApplyMovement(this.CurrentDirection);
            }
        }

        private void ApplyMovement(Direction direction)
        {
            int x = this.CurrentPosition.X + (int)direction.X;
            int y = this.CurrentPosition.Y + (int)direction.Y;
            this.CurrentPosition.O = direction.Orienation;

            this.CurrentPosition.X = x;
            this.CurrentPosition.Y = y;

            this.CurrentDirection = direction;
        }

        private void ApplyTrackMovement(Direction direction)
        {
            int x = this.CurrentPosition.X + (int)direction.X;
            int y = this.CurrentPosition.Y + (int)direction.Y;
            this.CurrentPosition.O = this.TargetShip.CurrentPosition.O;

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
            if (this.TargetShip != null)
            {
                this.TrackTarget();
            }
            else
            {
                this.GetNextPosition();
            }

            base.OnPropertyChanged(() => this.CurrentPosition);
            base.OnPropertyChanged(() => this.Radar);
        }

        public void TrackTarget()
        {
            Direction dir = Direction.Directions[0];
            if (this.TargetShip.CurrentPosition.X > this.CurrentPosition.X)
            {
                dir = Universal.GetRandomItem(Direction.Directions.Where(d => d.Id.Contains('E')).ToList());
            }

            if (this.TargetShip.CurrentPosition.X < this.CurrentPosition.X)
            {
                dir = Universal.GetRandomItem(Direction.Directions.Where(d => d.Id.Contains('W')).ToList());
            }

            if (this.TargetShip.CurrentPosition.Y > this.CurrentPosition.Y)
            {
                dir = Universal.GetRandomItem(Direction.Directions.Where(d => d.Id.Contains('N')).ToList());
            }

            if (this.TargetShip.CurrentPosition.Y < this.CurrentPosition.Y)
            {
                dir = Universal.GetRandomItem(Direction.Directions.Where(d => d.Id.Contains('S')).ToList());
            }

            if (this.TargetShip.CurrentPosition.X > this.CurrentPosition.X && this.TargetShip.CurrentPosition.Y > this.CurrentPosition.Y)
            {
                dir = Universal.GetRandomItem(Direction.Directions.Where(d => d.Id.Contains('E') && d.Id.Contains('N')).ToList());
            }

            if (this.TargetShip.CurrentPosition.X > this.CurrentPosition.X && this.TargetShip.CurrentPosition.Y < this.CurrentPosition.Y)
            {
                dir = Universal.GetRandomItem(Direction.Directions.Where(d => d.Id.Contains('E') && d.Id.Contains('S')).ToList());
            }

            if (this.TargetShip.CurrentPosition.X < this.CurrentPosition.X && this.TargetShip.CurrentPosition.Y > this.CurrentPosition.Y)
            {
                dir = Universal.GetRandomItem(Direction.Directions.Where(d => d.Id.Contains('W') && d.Id.Contains('N')).ToList());
            }

            if (this.TargetShip.CurrentPosition.X < this.CurrentPosition.X && this.TargetShip.CurrentPosition.Y < this.CurrentPosition.Y)
            {
                dir = Universal.GetRandomItem(Direction.Directions.Where(d => d.Id.Contains('W') && d.Id.Contains('S')).ToList());
            }

            this.ApplyMovement(dir);
        }
    }
}