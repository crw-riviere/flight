using RadarSim.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RadarSim.ViewModel
{
    public partial class ShipViewModel
    {
        public static ShipViewModel GetShip()
        {
            return new ShipViewModel()
            {
                ShipID = Universal.RandomInt(99).ToString(),
                Colour = Brushes.Black,
                CurrentPosition = new Position() { X = Universal.RandomInt(500), Y = Universal.RandomInt(500) },
                CurrentDirection = Direction.Directions[0]
            };
        }
    }
}