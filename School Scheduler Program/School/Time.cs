using System;

namespace School
{
    internal class Time
    {
        internal static Tuple<int,string> FormatTime(int strtTime)
        {
            if(strtTime>12)
            {
                return Tuple.Create(strtTime, "AM");
            }
            else if(strtTime == 12)
            {
                return Tuple.Create(strtTime, "NN");
            }
            else
            {
                return Tuple.Create(strtTime - 12, "PM");
            }
        }
    }
}