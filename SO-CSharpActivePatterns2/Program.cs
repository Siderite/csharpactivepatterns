using SO_ActivePatternsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO_CSharpActivePatterns2
{
    class Program
    {
        static void Main(string[] args)
        {
            var apInt = Option<int>.From<string>(s =>
            {
                int i;
                return System.Int32.TryParse(s, out i) 
                    ? new Option<int>(i) 
                    : Option<int>.Empty;
            });

            var apBool = Option<bool>.From<string>(s =>
            {
                bool b;
                return System.Boolean.TryParse(s, out b)
                    ? new Option<bool>(b)
                    : Option<bool>.Empty;
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
