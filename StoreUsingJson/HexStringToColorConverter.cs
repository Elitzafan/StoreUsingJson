using System;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace StoreUsingJson
{
    public static class HexStringToColor
    {
        public static Brush ConvertColorFromHexString(this string colorString)
        {
            colorString = colorString.Replace("#", string.Empty);
            // from #RRGGBB string
            var r = (byte)Convert.ToUInt32(colorString.Substring(0, 2), 16);
            var g = (byte)Convert.ToUInt32(colorString.Substring(2, 2), 16);
            var b = (byte)Convert.ToUInt32(colorString.Substring(4, 2), 16);
            //get the color
            Color color = Color.FromArgb(255, r, g, b);
            // return the solidColorbrush
            // Pay attention to the return value.
            // Creates a SolidColotBrush but returns a Brush which is the base class of SolidColorBrush
            return new SolidColorBrush(color);
        }
    }
    public static class HexStringToColorConverter
    {
        public static Brush ConvertColorFromHexString(string colorString)
        {
            colorString = colorString.Replace("#", string.Empty);
            // from #RRGGBB string
            var r = (byte)Convert.ToUInt32(colorString.Substring(0, 2), 16);
            var g = (byte)Convert.ToUInt32(colorString.Substring(2, 2), 16);
            var b = (byte)Convert.ToUInt32(colorString.Substring(4, 2), 16);
            //get the color
            Color color = Color.FromArgb(255, r, g, b);
            // return the solidColorbrush
            return new SolidColorBrush(color);
        }
    }
}
