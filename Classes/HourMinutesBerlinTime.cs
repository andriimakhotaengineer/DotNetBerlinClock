using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    /*
     * Class for storing hours and minutes 
     * with support of 24:00 value
     */
    class HourMinutesBerlinTime
    {
        private int hour = 0;
        private int min = 0;

        public HourMinutesBerlinTime(int aH, int aM) {            
            Hour = aH;
            Minute = aM;   
        }

        public int Hour {
            get { return hour; }
            set { 
                // value must be between 0 and 23 or it can be 24 if minutes value is 0
                if ((value >= 0) && (value <= 23) || (value == 24) && (min == 0))
                {
                    hour = value;
                }
                else {
                    throw new ArgumentOutOfRangeException("Hour", "Hour value must be between 0 and 23 or it can be 24 and minutes must been 0");
                }
            }
        }
        public int Minute{
            get { return min; }
            set {
                //     value must be between 0 and 59 
                // BUT it can be only 0 if hours value is 24
                if (((value >= 0) && (value <= 59) && (hour < 24))||((hour == 24)&&(value == 0)))
                {
                    min = value;
                }
                else if ((hour == 24)&&(value != 0)) {
                    throw new ArgumentOutOfRangeException("Minute", "If hour = 24 then minutes can be only 0");
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Minute", "Minute value must be between 0 and 59");
                }
            } 
        }
    }
}
