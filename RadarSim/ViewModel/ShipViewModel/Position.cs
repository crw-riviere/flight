using RadarSim.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarSim.ViewModel
{
    public class Position
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        public int O { get; set; }

        #region constructors

        public Position()
        {
        }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Position(int x, int y, int z, int o)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.O = o;
        }

        #endregion constructors
    }
}

//switch (r)
//{
//    case 1: direction = Direction.Directions["N"]; break;
//    case 2: direction = Direction.Directions["NE"]; break;
//    case 3: direction = Direction.Directions["E"]; break;
//    case 4: direction = Direction.Directions["SE"]; break;
//    case 5: direction = Direction.Directions["S"]; break;
//    case 6: direction = Direction.Directions["SW"]; break;
//    case 7: direction = Direction.Directions["W"]; break;
//    case 8: direction = Direction.Directions["NW"]; break;
//    default: break;
//}