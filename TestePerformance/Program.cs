using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesPerformance;

namespace TestePerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            Old();
            New();
            Console.ReadKey();
        }
        private static void Old()
        {
            Console.WriteLine($"int.Parse:");
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 50_000_000; i++)
            {
                var intValue = int.Parse("1398675245");
                if (intValue != 1398675245) throw new Exception();
            }
            sw.Stop();
            Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds}ms");
        }
        private static void New()
        {
            Console.WriteLine($"Recursive:");
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 50_000_000; i++)
            {
                var intValue = Converter.ToInt("1398675245");
                if (intValue != 1398675245) throw new Exception();
            }
            sw.Stop();
            Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds}ms");
        }
        private static void TesteIdDigit()
        {
            Func<char, bool> isDigit = VerificacaoIsDigit.IsDigit;

            var sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < 1_000_000_00; i++)
                Ifs(isDigit);

            sw.Stop();
            Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds}ms");

            isDigit = VerificacaoIsDigit.IsDigitDefault;


            sw.Reset();
            sw.Start();

            for (int i = 0; i < 1_000_000_00; i++)
                Ifs(isDigit);

            sw.Stop();
            Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }

        private static void Ifs(Func<char, bool> isDigit)
        {
            if (!isDigit('0')) { throw new Exception("Error!"); }
            if (!isDigit('1')) { throw new Exception("Error!"); }
            if (!isDigit('2')) { throw new Exception("Error!"); }
            if (!isDigit('3')) { throw new Exception("Error!"); }
            if (!isDigit('4')) { throw new Exception("Error!"); }
            if (!isDigit('5')) { throw new Exception("Error!"); }
            if (!isDigit('6')) { throw new Exception("Error!"); }
            if (!isDigit('7')) { throw new Exception("Error!"); }
            if (!isDigit('8')) { throw new Exception("Error!"); }
            if (!isDigit('9')) { throw new Exception("Error!"); }

            if (isDigit('๑')) { throw new Exception("Error!"); }
            if (isDigit('A')) { throw new Exception("Error!"); }
            if (isDigit('a')) { throw new Exception("Error!"); }
            if (isDigit('"')) { throw new Exception("Error!"); }
            if (isDigit('\'')) { throw new Exception("Error!"); }
            if (isDigit('.')) { throw new Exception("Error!"); }
            if (isDigit(',')) { throw new Exception("Error!"); }
        }
    }
}
