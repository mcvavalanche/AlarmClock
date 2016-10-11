using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlarmClock.Core.Sservices;
using AlarmClock.Core.ViewModel;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace AlarmClock.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        private readonly ILoginService _service;
        public AppStart(ILoginService service)
        {
            _service = service;
        }

        public async void Start(object hint = null)
        {
            //hardcoded login for this demo
            //var userService = Mvx.Resolve<IUserDataService>();
            //await userService.Login("gillcleeren", "123456");

            if (!_service.IsLoggedIn)
            {
                ShowViewModel<LoginViewModel>();
            }
            else
            {
                ShowViewModel<MainViewModel>();
            }
        }
    }
}
