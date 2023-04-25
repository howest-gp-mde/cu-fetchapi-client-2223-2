using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Mde.FetchClient.Converters
{
    public class ColorToHexCodeConverter : IValueConverter
    {
        /// <summary>
        /// converts a Color to Hex code
        /// </summary>
        /// <param name="value">a Color instance</param>
        /// <returns>a string representing the hex code</returns>
        /// <exception cref="NotImplementedException"></exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is Color))
                throw new ArgumentException($"value should be of type {typeof(Color).FullName}", nameof(value));
            
            var color = (Color)value;
            string hexWithOpacity = color.ToHex().ToLower();
            return $"#{hexWithOpacity.Substring(3, 6)}";
        }

        //Hex code to Color
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
                throw new ArgumentException($"value should be of type string", nameof(value));

            string hex = (string)value;
            return Color.FromHex(hex);
        }
    }
}
