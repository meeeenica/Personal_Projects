using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class DailySched
    {
        public string weekday { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string StartAMPM { get; set; }
        public string EndAMPM { get; set; }

        public DailySched(string weekday, int StartTime, string StartAMPM, string EndAMPM, int Duration)
        {
            this.weekday = weekday;
            this.StartTime = StartTime;
            this.StartAMPM = StartAMPM;
            this.EndTime = SetEndTime(StartTime, Duration).Item1;
            this.EndAMPM = SetEndTime(StartTime, Duration).Item2;
        }

        private Tuple<int, string> SetEndTime(int StartTime, int duration)
        {
            int endtime = 0;
            endtime = StartTime + duration;
            if(endtime>12)
            {
                return Tuple.Create(endtime-12, "PM");
            }
            if (endtime == 12)
            {
                return Tuple.Create(12, "NN");
            }
            else
            {
                return Tuple.Create(endtime, "AM");
            }
        }
    }
}
