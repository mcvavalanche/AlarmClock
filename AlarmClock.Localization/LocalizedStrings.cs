using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock.Localization
{
    public class LocalizedStrings
    {
        public LocalizedStrings() { }

        private static readonly Resources LocalizedStringsResources
            = new Resources();

        public Resources Strings => LocalizedStringsResources;
    }
}
