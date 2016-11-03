using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using MvvmCross.WindowsUWP.Views;

namespace AlarmClock.Win
{
    public static class RegionAttributeExtentionMethods
    {
        public static bool HasRegionAttribute(this IMvxWindowsView view)
        {
            var attributes = view
                .GetType()
                .GetCustomAttributes(typeof(RegionAttribute), true);

            return attributes.Any();
        }

        public static string GetRegionName(this IMvxWindowsView view)
        {
            var attributes = view
                .GetType()
                .GetCustomAttributes(typeof(RegionAttribute), true);

            if (!attributes.Any())
                throw new InvalidOperationException("The IMvxView has no region attribute.");

            return ((RegionAttribute)attributes.First()).Name;
        }
    }
}
