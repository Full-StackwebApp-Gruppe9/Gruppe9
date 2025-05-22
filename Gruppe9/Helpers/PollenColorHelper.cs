using Gruppe9.Models;

namespace Gruppe9.Helpers
{
    public static class PollenColorHelper
    {
        public static ColorInfo GetColorForValue(int value)
        {
            return value switch
            {
                <= 2 => new ColorInfo { Red = 0, Green = 200, Blue = 0 },   // Grønn
                <= 4 => new ColorInfo { Red = 255, Green = 255, Blue = 0 }, // Gul
                _ => new ColorInfo { Red = 255, Green = 0, Blue = 0 }    // Rød
            };
        }
    }
}
