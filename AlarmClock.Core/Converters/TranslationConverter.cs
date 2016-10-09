using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Localization;
using MvvmCross.Platform.Converters;

namespace AlarmClock.Core.Converters
{
    public class TranslationConverter: IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as MvxLanguageBinder)?.GetText(parameter.ToString()) ?? parameter;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
