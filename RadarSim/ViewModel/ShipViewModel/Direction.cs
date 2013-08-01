using RadarSim.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarSim.ViewModel
{
    public class Direction
    {
        public enum Symbol
        {
            Negative = -1,
            Positive = 1,
            Neutral = 0
        };

        public List<char> Id { get; set; }

        public Symbol X { get; set; }

        public Symbol Y { get; set; }

        public int Orienation { get; set; }

        public static Direction[] Directions = new Direction[8]
            {
               new Direction(new List<char>(){'N'},Symbol.Neutral,Symbol.Positive,0),
               new Direction(new List<char>(){'N','E'},Symbol.Positive,Symbol.Positive,45),
               new Direction(new List<char>(){'E'},Symbol.Positive,Symbol.Neutral,90),
               new Direction(new List<char>(){'S','E'},Symbol.Positive,Symbol.Negative,135),
               new Direction(new List<char>(){'S'},Symbol.Neutral,Symbol.Negative,180),
               new Direction(new List<char>(){'S','W'},Symbol.Negative,Symbol.Negative,225),
               new Direction(new List<char>(){'W'},Symbol.Negative,Symbol.Neutral,270),
               new Direction(new List<char>(){'N','W'},Symbol.Negative,Symbol.Positive,315),
            };

        public Direction()
        {
        }

        public Direction(List<char> id, Symbol x, Symbol y, int orientation)
        {
            this.Id = id;
            this.X = x;
            this.Y = y;
            this.Orienation = orientation;
        }

        public Direction GetOppositeDirection()
        {
            List<Direction> oppositeDirections = Directions.Where(d => !d.Id.Any(id => this.Id.Contains(id))).ToList();
            return Universal.GetRandomItem(oppositeDirections);
        }

        public override string ToString()
        {
            return this.Id.ToString();
        }
    }
}