using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    class TimeStringParser
    {
        /*
         * Class for parsing time input string
         */
        public HourMinutesBerlinTime GetTime(string aTime) {
            try
            {
                // trying to use standart parser
                DateTime dt = DateTime.ParseExact(aTime, "HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                return new HourMinutesBerlinTime(dt.Hour, dt.Minute);
            }
            catch (FormatException exc) {
                // check if string 24:00 - it is forbidden for DateTime from .Net
                // but valid for BerlinClock
                if (aTime.Equals("24:00:00")||aTime.Equals("24:00"))
                {
                    return new HourMinutesBerlinTime(24, 0);
                }
                else {
                    throw exc;
                }
            }
        }
    }
}
