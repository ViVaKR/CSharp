using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_TypeConversion
{
    /// <summary>
    /// implicit demo
    /// </summary>
    public class Digit
    {
        private byte digit;
        public Digit(byte digit)
        {
            if (digit > 9) throw new ArgumentException(nameof(digit), "Digit cannot be greater than nine");
            this.digit = digit;
        }

        /// <summary>
        /// Digit to byte
        /// </summary>
        /// <param name="d"></param>
        public static implicit operator byte(Digit d) => d.digit;

        /// <summary>
        /// byte to Digit
        /// </summary>
        /// <param name="b"></param>
        public static explicit operator Digit(byte b) => new Digit(b);
    }

}
