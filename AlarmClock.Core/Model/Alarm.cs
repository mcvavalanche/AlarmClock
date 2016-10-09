using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AlarmClock.Core.ViewModel;
using MvvmCross.Core.ViewModels;

namespace AlarmClock.Core.Model
{
    public class Alarm: MvxViewModel
    {
        private bool _repeat;
        public string Name { get; set; }
        public DateTime AlarmTime { get; set; }

        public bool Repeat
        {
            get { return _repeat; }
            set
            {
                _repeat = value;
                //OnPropertyChanged();
                RaisePropertyChanged(()=>Repeat);
            }
        }
        private MvxCommand _edit;

        public ICommand EditAlarm => _edit ?? (_edit = new MvxCommand(Edit));

        private void Edit()
        {
            ShowViewModel<AlarmDetailsViewModel>(new {Id = 1});
        }
    }


}
