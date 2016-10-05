using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace AlarmClock.Core.ViewModel
{
    public class MainViewModel : MvxViewModel, IMainViewModel
    {
        private TimeSpan _time;

        public MainViewModel()
        {
            _time = DateTime.Now.TimeOfDay;
        }

        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                _time = value;
                RaisePropertyChanged(()=>Time);
            }
        }

        private MvxCommand _click;

        public ICommand Click => _click ?? (_click = new MvxCommand(DoStuff));

        private void DoStuff()
        {
            Time = _time.Add(new TimeSpan(1, 0, 0));
        }

    }
}
