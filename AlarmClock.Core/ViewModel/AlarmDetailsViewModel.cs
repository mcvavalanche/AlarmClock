using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AlarmClock.Core.Interfaces;
using MvvmCross.Core.ViewModels;

namespace AlarmClock.Core.ViewModel
{
    public class AlarmDetailsViewModel : MvxViewModel, IAlarmDetailsViewModel
    {
        public AlarmDetailsViewModel()
        {
        }

        public void Init(int index)
        {
            // use the index here
        }

        private MvxCommand _saveCmd;
        public ICommand SaveCmd => _saveCmd ?? (_saveCmd = new MvxCommand(Save));
        private void Save()
        {
            Close(this);
        }

    }
}
