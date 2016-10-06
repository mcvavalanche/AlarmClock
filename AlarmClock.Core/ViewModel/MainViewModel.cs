using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AlarmClock.Core.Model;
using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;

namespace AlarmClock.Core.ViewModel
{
    public class MainViewModel : MvxViewModel, IMainViewModel
    {
        private TimeSpan _time;
        private MvxCommand _click;
        private List<Alarm> _alarms;

        public MainViewModel()
        {
            _time = DateTime.Now.TimeOfDay;
            Alarms = new List<Alarm>()
            {
                new Alarm() {Name = "alarm1"},
                new Alarm() {Name = "alarm2"},
                new Alarm() {Name = "alarm3"}
            };
        }
        

        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                _time = value;
                RaisePropertyChanged(() => Time);
            }
        }

        public List<Alarm> Alarms { get; set; }

        public ICommand Click => _click ?? (_click = new MvxCommand(DoStuff));

        private void DoStuff()
        {
            Time = _time.Add(new TimeSpan(1, 0, 0));
        }


        public IMvxLanguageBinder TextSource => new MvxLanguageBinder(null, GetType().Name);
    }
}
