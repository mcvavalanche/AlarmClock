using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlarmClock.Core.Utility;
using Microsoft.VisualBasic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace AlarmClock.Core
{
    /*     
     * MVX - A Windows Universal App Platform Project - Tip App Example
     * https://mvvmcross.com/docs/a-windows-universal-app-platform-project
     * 
     * Understanding TargetDeviceFamily
     * http://blog.jerrynixon.com/2016/07/understanding-targetdevicefamily.html
     * 
     * Intro to the Universal Windows Platform
     * https://msdn.microsoft.com/en-us/windows/uwp/get-started/universal-application-platform-guide?f=255&MSPPError=-2147217396     
     * 
     * UWP Design & UI
     * https://developer.microsoft.com/en-us/windows/design
     * 
     * 8 traits of great Metro style apps     * 
     * https://channel9.msdn.com/Events/BUILD/BUILD2011/BPS-1004
     */

    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterSingleton<IMvxTextProvider> (new ResxTextProvider(AlarmClock.Localization.Strings.ResourceManager));

            RegisterAppStart(new AppStart());
        }
    }
}
