using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock.Core.Model
{
    public class Alarm
    {
        public string Name { get; set; }
        public DateTime AlarmTime { get; set; }
        public bool Repeat { get; set; }

    }

    public enum ReccurenceType
    {
        None,
        Daily,
        Weekly,
        Monthly,
        Yearly,
        Custom
    }

    public class BaseReccurence
    {
        public BaseReccurence()
        {
            Type=ReccurenceType.Custom;
            Infinite = true;
            StartDate= RoundUp(DateTime.Now);
        }

        private DateTime RoundUp(DateTime date)
        {
            return date;
        }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Repeats { get; set; }
        public bool Infinite { get; set; }
        public ReccurenceType Type { get; set; }
    }

    public interface IReccurence
    {
        DateTime StartDate { get; set; }
        ReccurenceType Type { get; set; }
        DateTime? EndDate { get; set; }
        int? Repeats { get; set; }
        bool Infinite { get; set; }
        DateTime GetNextDate(DateTime date);
    }

    public class CustomReccurence:BaseReccurence, IReccurence
    {
        public int Milliseconds { get; set; }

        public CustomReccurence(int ms)
        {
            Milliseconds = ms;
        }
        public DateTime GetNextDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
