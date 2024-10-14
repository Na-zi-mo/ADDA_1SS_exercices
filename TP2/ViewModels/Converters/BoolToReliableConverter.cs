using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.ViewModels.Converters
{
    public class BoolToReliableConverter
    {
        // Conv Model To View
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isReliable)
            {
                return isReliable ? "Oui" : "Non";
            }
            return "";
        }

        // Conv View To Model
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
