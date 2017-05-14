using SO_ActivePatternsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO_CSharpActivePatterns3
{
    class Program
    {
        static void Main(string[] args)
        {
            var apInt = FluidFunc.From<string,int>(s =>
            {
                int i;
                return System.Int32.TryParse(s, out i)
                    ? new Tuple<bool, int>(true, i)
                    : new Tuple<bool, int>(false, 0);
            });

            var apBool = FluidFunc.From<string,bool>(s =>
            {
                bool b;
                return System.Boolean.TryParse(s, out b)
                    ? new Tuple<bool, bool>(true, b)
                    : new Tuple<bool, bool>(false, false);
            });

            var testParse = new Action<string>(s =>
            {
                FluidFunc
                    .Match(s)
                    .With(apInt, r => Console.WriteLine($"The value is an int '{r}'"))
                    .With(apBool, r => Console.WriteLine($"The value is an bool '{r}'"))
                    .Else(v => Console.WriteLine($"The value '{v}' is something else"));
            });

            testParse("12");
            testParse("true");
            testParse("abc");

            System.Console.ReadKey();
        }
    }
}
