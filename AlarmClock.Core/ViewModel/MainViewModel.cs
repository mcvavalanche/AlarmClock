using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AlarmClock.Core.Model;
using AlarmClock.Localization;
using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;

namespace AlarmClock.Core.ViewModel
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {

        private MvxCommand _click;
        public ICommand Button1Clicked => _click ?? (_click = new MvxCommand(DoStuff));

        private void DoStuff()
        {
            ShowViewModel<LoginViewModel>();
        }


        private MvxCommand _click2;
        public ICommand Button2Clicked => _click2 ?? (_click2 = new MvxCommand(DoStuff2));

        private void DoStuff2()
        {

            ShowViewModel<AlarmsViewModel>();
        }
    }
}
