using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_TypeConversion
{
    public class Fahrenheit : Temperature
    {
        public Fahrenheit(double degree) : base(degree) { }

        /// <summary>
        /// ( explicit )F => C explicit convert
        /// </summary>
        /// <param name="fahrenheit"></param>
        public static explicit operator Celsius(Fahrenheit fahrenheit)
        => new Celsius((fahrenheit.Degree - 32) * (5.0 / 9.0));
    }

}
