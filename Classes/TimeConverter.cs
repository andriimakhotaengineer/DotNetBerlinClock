using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private int hours5x; // 5x hours indicator value
        private int hours1x; // single hour indicator value
        private int minutes5x;// 5x minute indicator value
        private int minutes1x;// single minute indicator value
        private bool isAM;    // is now before or after midday

        public string convertTime(string aTime)
        {
            TimeStringParser parser = new TimeStringParser();
            HourMinutesBerlinTime dt = parser.GetTime(aTime);
            if ((dt.Hour < 12)||
                (dt.Hour == 24) // 24 is ante meridiem
                ) {
                isAM = true;
            }
            else{
                isAM = false;
            }
            hours5x = (int)Math.Floor(dt.Hour / 5.0);
            hours1x = dt.Hour - hours5x * 5;

            minutes5x = (int)Math.Floor(dt.Minute / 5.0);
            minutes1x = dt.Minute - minutes5x * 5;
            return GetTimeRepresentationString();
        }
        private String GetTimeRepresentationString() {
            /*
             * function form output string for BerlinClock
             */
            String strRetValue = "";            
            if (isAM) {
                strRetValue += "Y";
            }
            else
            {
                strRetValue += "O";
            }
            int i;
            strRetValue += System.Environment.NewLine;
            for (i = 0; i < hours5x; i ++)
            {                
                strRetValue += "R";                                    
            }
            for (; i < 4; i++)
            {                
                strRetValue += "O";                                    
            }
            strRetValue += System.Environment.NewLine;
            for (i = 0; i < hours1x; i++)
            {
                strRetValue += "R";
            }
            for (; i < 4; i++)
            {
                strRetValue += "O";
            }
            strRetValue += System.Environment.NewLine;
            for (i = 0; i < minutes5x; i++)
            {
                if ((i == 2) || (i == 5) || (i == 8))// check for quarter of hour                
                {
                    strRetValue += "R";
                }
                else { 
                    strRetValue += "Y";
                }
            }
            for (; i < 11; i++)
            {
                strRetValue += "O";
            }
            strRetValue += System.Environment.NewLine;
            for (i = 0; i < minutes1x; i++)
            {
                strRetValue += "Y";
            }
            for (; i < 4; i++)
            {
                strRetValue += "O";
            }            
            return strRetValue;
        }
    }
}
