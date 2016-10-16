using System;
using MvvmCross.Platform.Converters;
namespace CoffeeManagerAdmin.iOS
{
    public class DecimalToStringConverter : MvxValueConverter<decimal, string>
    {
        protected override string Convert(decimal value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString("F");
        }
    }
}
