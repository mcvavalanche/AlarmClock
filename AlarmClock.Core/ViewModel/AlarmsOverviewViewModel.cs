using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AlarmClock.Core.Model;
using MvvmCross.Core.ViewModels;

namespace AlarmClock.Core.ViewModel
{
    public class AlarmsOverviewViewModel: BaseViewModel
    {
        private TimeSpan _time;

        public AlarmsOverviewViewModel()
        {
            _time = DateTime.Now.TimeOfDay;
            Alarms = new List<Alarm>()
            {
                new Alarm() {Name = "Alarm 1", AlarmTime = new DateTime(2016,1,10)},
                new Alarm() {Name = "Alarm 2", AlarmTime = new DateTime(2016,2,10)},
                new Alarm() {Name = "Alarm 3", AlarmTime = new DateTime(2016,3,10)},
                new Alarm() {Name = "Alarm 4", AlarmTime = new DateTime(2016,4,10)}
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

        private MvxCommand _click;
        private Alarm _selectedItem;

        public ICommand Click => _click ?? (_click = new MvxCommand(DoStuff));

        private void DoStuff()
        {
            Time = _time.Add(new TimeSpan(1, 0, 0));
        }



        public List<Alarm> Alarms { get; set; }

        public Alarm SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }

    }
}
