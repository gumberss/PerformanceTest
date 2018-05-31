using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePerformance
{
    public static class Converter
    {
        public static int ConverteParse(String number)
        {
            return int.Parse(number);
        }

        public static int ToInt(String strNumber)
        {
            return ConvertRecursive(strNumber, strNumber.Length);
        }

        private static int ConvertRecursive(String number, int length, int recursion = 0, int multiplier = 1)
        {
            if (length == recursion) return 0;

            var next = ConvertRecursive(number, length, ++recursion, multiplier * 10);

            var value = number[length - recursion] - '0';

            return value * multiplier + next;
        }
    }
}
