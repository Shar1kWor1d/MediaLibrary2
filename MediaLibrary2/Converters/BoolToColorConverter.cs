using System.Globalization;

namespace MediaLibrary2.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public BoolToColorConverter()
        {
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return Colors.BlueViolet;
            }
            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

