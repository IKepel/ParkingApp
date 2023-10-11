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

        /// <summary>
        /// Initializes a new instance of the Color class with the specified RGB values and opacity.
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="opacity"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Color(int red, int green, int blue, int opacity)
        {
            if (IsValidColor(red) && IsValidColor(green) && IsValidColor(blue) && opacity >= 0 && opacity >= 100)
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

        /// <summary>
        /// Object Color with default params
        /// </summary>
        public Color()
        {
            _red = 0;
            _green = 0;
            _blue = 0;
            _opacity = 100; 
        }

        /// <summary>
        /// Returns a string representation of the color in the format "RGBA(R, G, B, A%)".
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"RGBA({_red}, {_green}, {_blue}, {_opacity}%)";
        }

        /// <summary>
        /// Checks if the provided color component value is within the valid range (0-255).
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsValidColor(int value)
        {
            if (value >= 0 && value <= 255)
            {
                return true;
            }
            else return false;
        }
    }
}