using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_TypeConversion
{
    // 명시적, 암묵적 형변환
    public class Temperature
    {
        public double Degree { get; }

        public Temperature(double degree) => Degree = degree;

        /// <summary>
        /// Print converted type of Temperature
        /// </summary>
        /// <param name="degree">double</param>
        /// <param name="typeOfTemp">true = C, false = F</param>
        public void Output(double degree, bool typeOfTemp)
        {
            Console.WriteLine($"{Title(typeOfTemp)}: {degree} => {Title(!typeOfTemp)}: {Degree:n1}");
        }

        private string Title(bool typeOfTemp)
        => typeOfTemp ? nameof(Celsius) : nameof(Fahrenheit);
    }

}
