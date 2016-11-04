using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace AlarmClock.Core.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {

        private MvxCommand _click;
        public ICommand Login => _click ?? (_click = new MvxCommand(DoStuff));

        private void DoStuff()
        {
            ShowViewModel<MainViewModel>();
        }
    }
}
