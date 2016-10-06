using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;
using MvvmCross.Platform.Converters;
using MvvmCross.WindowsUWP.Platform;

namespace AlarmClock.Win
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }


        //protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        //{
        //    //base.FillValueConverters(registry);
        //    registry.AddOrOverwrite("Language", new MvxLanguageConverter());
        //}
    }
}
