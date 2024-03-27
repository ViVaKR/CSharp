using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_TypeConversion
{
    public class Celsius : Temperature
    {
        public Celsius(double degree) : base(degree) { }

        /// <summary>
        /// ( explicit ) C => F explicit convert 
        /// </summary>
        /// <param name="celsius"></param>
        public static explicit operator Fahrenheit(Celsius celsius)
        => new Fahrenheit(celsius.Degree * (9.0 / 5.0) + 32);
    }

}
