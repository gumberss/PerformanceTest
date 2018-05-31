using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePerformance
{
    public class VerificacaoIsDigit
    {
        public static bool IsDigit(char value)
        {
            var result = value - '0';

            return result >= 0 && result < 10;
        }

        public static bool IsDigitDefault(char value)
        {
            return char.IsDigit(value);
        }
    }
}
