using RadarSim.Command;
using RadarSim.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace RadarSim.ViewModel
{
    public class SimViewModel : BaseViewModel
    {
        private static DispatcherTimer time;
        private SimpleCommand execSimCmd;

        public static DispatcherTimer Time
        {
            get
            {
                if (time == null)
                {
                    time = new DispatcherTimer();
                    time.Interval = new TimeSpan(0, 0, 0, 0, 100);
                }
                return time;
            }
        }

        public SimpleCommand ExecSimCmd
        {
            get
            {
                return this.execSimCmd;
            }
            set
            {
                this.execSimCmd = value;
            }
        }

        public int Speed
        {
            get
            {
                return Time.Interval.Milliseconds;
            }
            set
            {
                Time.Interval = new TimeSpan(0, 0, 0, 0, value);
            }
        }

        public SimViewModel()
        {
            this.Zone = new ZoneViewModel();
            this.ExecSimCmd = new SimpleCommand(() => this.ExecuteSim());
        }

        public ZoneViewModel Zone { get; set; }

        public void ExecuteSim()
        {
            if (Time.IsEnabled)
            {
                Time.Stop();
            }
            else
            {
                Time.Start();
            }
        }
    }
}