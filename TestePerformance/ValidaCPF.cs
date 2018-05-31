using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesPerformance
{
    /// <summary>
	/// Realiza a validação do CPF
	/// </summary>
	public static class ValidaCPF
    {
        public static bool IsCpf(string cpf)
        {
            //validar se todos são digitos
            //if (cpf.Length != 11) return false;

            int resto = 0, countDigit = 0, somaDigito1 = 0, somaDigito2 = 0, digit1 = 0, digit2 = 0;

            foreach (var current in cpf)
            {
                if (char.IsDigit(current))
                {
                    if (countDigit < 9)
                    {
                        somaDigito1 += (current - '0') * (10 - countDigit);
                        somaDigito2 += (current - '0') * (11 - countDigit);
                    }
                    else if (countDigit == 9)
                    {
                        digit1 = current;
                    }
                    else if (countDigit == 10)
                    {
                        digit2 = current;
                    }

                    countDigit++;
                }
            }

            resto = somaDigito1 % 11;

            var dg1 = resto < 2 ? 0 : 11 - resto;

            somaDigito2 += dg1 * 2;

            resto = somaDigito2 % 11;

            var dg2 = resto < 2 ? 0 : 11 - resto;

            return cpf[cpf.Length - 2] - '0' == dg1 && cpf[cpf.Length - 1] - '0' == dg2;
        }
    }
}
