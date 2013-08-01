using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace RadarSim.Resource
{
    public static class Universal
    {
        private static Random r = new Random();

        public static int RandomInt(int maxValue)
        {
            return r.Next(maxValue);
        }

        public static bool RandomBool()
        {
            return r.Next(1) == 1 ? true : false;
        }

        public static T GetRandomItem<T>(List<T> items)
        {
            return items.ElementAtOrDefault(RandomInt(items.Count));
        }
    }
}