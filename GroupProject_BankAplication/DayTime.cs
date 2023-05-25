using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_BankAplication
{
    public struct DayTime
    {
        // DayTime field
        private long minutes;

        // DayTime Constructor
        public DayTime( long minutes )
        {
            this.minutes = minutes;
        }

        // DayTime Addition operator overload
        public static DayTime operator +( DayTime lhs, int minute )
        {
            return new DayTime( lhs.minutes + minute);
        }

        // DayTime ToString method override
        public override string ToString()
        {
            long remainingMinutes = minutes;

            long year = remainingMinutes / 518400;
            remainingMinutes %= 518400;

            long month = remainingMinutes / 43200;
            remainingMinutes %= 43200;

            long day = remainingMinutes / 1440;
            remainingMinutes %= 1440;

            long hour = remainingMinutes / 60;
            remainingMinutes %= 60;

            return string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}", year, month + 1, day + 1, hour, remainingMinutes);
        }
    }
}
