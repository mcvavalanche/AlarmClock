using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Localization;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;

namespace AlarmClock.Core.Converters
{
    public class LanguageConverter: IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((IMvxLanguageBinder)value).GetText(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
