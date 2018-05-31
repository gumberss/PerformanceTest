using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePerformance
{
    /// <summary>
    /// http://www.elemarjr.com/pt/2018/05/validando-cnpj-respeitando-o-garbage-collector/
    /// </summary>
    public struct CnpjElemar
    {
        private readonly string _value;

        public readonly bool EhValido;
        static readonly int[] Multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        static readonly int[] Multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public CnpjElemar(string value)
        {
            _value = value;

            if (value == null)
            {
                EhValido = false;
                return;
            }

            var digitosIdenticos = true;
            var ultimoDigito = -1;
            var posicao = 0;
            var totalDigito1 = 0;
            var totalDigito2 = 0;

            foreach (var c in _value)
            {
                var digito = c - '0';
                if (digito >=0 && digito < 10)
                {

                    if (posicao != 0 && ultimoDigito != digito)
                    {
                        digitosIdenticos = false;
                    }

                    ultimoDigito = digito;
                    if (posicao < 12)
                    {
                        totalDigito1 += digito * Multiplicador1[posicao];
                        totalDigito2 += digito * Multiplicador2[posicao];
                    }
                    else if (posicao == 12)
                    {
                        var dv1 = (totalDigito1 % 11);
                        dv1 = dv1 < 2
                            ? 0
                            : 11 - dv1;

                        if (digito != dv1)
                        {
                            EhValido = false;
                            return;
                        }

                        totalDigito2 += dv1 * Multiplicador2[12];
                    }
                    else if (posicao == 13)
                    {
                        var dv2 = (totalDigito2 % 11);

                        dv2 = dv2 < 2
                            ? 0
                            : 11 - dv2;

                        if (digito != dv2)
                        {
                            EhValido = false;
                            return;
                        }
                    }

                    posicao++;
                }
            }

            EhValido = (posicao == 14) && !digitosIdenticos;
        }

        public static implicit operator CnpjElemar(string value)
            => new CnpjElemar(value);

        public override string ToString()
            => _value;
        public static bool ValidarCNPJ(CnpjElemar cnpj)
        => cnpj.EhValido;
    }
}
