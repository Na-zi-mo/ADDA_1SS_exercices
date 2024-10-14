using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TP2.ViewModels.Converters
{
    public class BoolToReliableConverter : IValueConverter
    {
        // Conv Model To View
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isReliable = (bool)value;
            return isReliable ? "Oui" : "Non";
        }

        // Conv View To Model
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
