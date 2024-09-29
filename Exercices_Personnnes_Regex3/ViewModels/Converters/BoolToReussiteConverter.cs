using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace test.ViewModels.Converters
{
    public class BoolToReussiteConverter : IValueConverter
    {
        // Conv Model To View
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool reussite = (bool) value;
            return reussite ? "Success!" : "Fail!" ;
        }

        // Conv View To Model
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
