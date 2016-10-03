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
     * https://msdn.microsoft.com/en-us/magazine/dn759442.aspx?f=255&MSPPError=-2147217396
     * https://mvvmcross.com/docs/a-windows-universal-app-platform-project
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
