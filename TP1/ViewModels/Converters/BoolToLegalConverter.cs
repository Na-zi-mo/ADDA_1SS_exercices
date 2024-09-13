using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TP1.ViewModels.Converters
{
    public class BoolToLegalConverter : IValueConverter
    {
        // Conv Model To View
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool illegal = (bool) value;
            return illegal ? TP1.Properties.traduction.column_bool_illegal : TP1.Properties.traduction.column_bool_legal ;
        }

        // Conv View To Model
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
