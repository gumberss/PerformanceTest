using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePerformance
{
    /// <summary>
    /// Realiza a validação do CNPJ
    /// </summary>
    public static class ValidaCNPJ
    {
        public static bool IsCnpj(string cnpj)
        {
            int countDigit = 0, somaDigit1 = 0, somaDigit2 = 0, digit1 = 0, digit2 = 0, rest = 0, mult1 = 5, mult2 = 6;

            foreach (var current in cnpj)
            {
                if (char.IsDigit(current))
                {
                    if (countDigit < 12)
                    {
                        somaDigit1 += (current - '0') * (mult1 - countDigit);
                        somaDigit2 += (current - '0') * (mult2 - countDigit);
                    }
                    if (countDigit == 12)
                    {
                        digit1 = current - '0';
                    }
                    if (countDigit == 13)
                    {
                        digit2 = current - '0';
                    }

                    countDigit++;

                    if (countDigit == 4)
                        mult1 = 13;
                    else if (countDigit == 5)
                        mult2 = 14;
                }
            }

            if (countDigit != 14) return false;

            rest = (somaDigit1 % 11);

            var digitVerify1 = rest < 2 ? 0 : 11 - rest;

            if (digit1 != digitVerify1) return false;

            somaDigit2 += (digitVerify1 * 2);

            rest = (somaDigit2 % 11);

            var digitVerify2 = rest < 2 ? 0 : 11 - rest;

            return digit2 == digitVerify2;
        }
    }
}
