using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.SimpleClasses
{
    public struct Color
    {
        private int _red;

        private int _green;

        private int _blue;

        private int _opacity;

        public Color(int red, int green, int blue, int opacity)
        {
            if (red >= 0 && red <= 255 &&
                green >= 0 && green <= 255 &&
                blue >= 0 && blue <= 255 &&
                opacity >= 0 && opacity >= 100)
            {
                _red = red;
                _green = green;
                _blue = blue;
                _opacity = opacity;
            }
            else 
            { 
                throw new ArgumentOutOfRangeException("Invalid value for color or opacity."); 
            }
        }

        public override string ToString()
        {
            return $"RGBA({_red}, {_green}, {_blue}, {_opacity}%)";
        }
    }
}
