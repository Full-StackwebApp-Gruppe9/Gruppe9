using Gruppe9.Models;

namespace Gruppe9.Helpers
{
    // Hjelpeklasse for å bestemme farge basert på pollennivå
    public static class PollenColorHelper
    {
        public static ColorInfo GetColorForValue(int value)
        {
            return value switch
            {
                <= 2 => new ColorInfo { Red = 0, Green = 200, Blue = 0 },   // Lavt nivå → grønn
                <= 4 => new ColorInfo { Red = 255, Green = 255, Blue = 0 }, // Moderat nivå → gul
                _ => new ColorInfo { Red = 255, Green = 0, Blue = 0 }       // Høyt nivå → rød
            };
        }
    }
}
