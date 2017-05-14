using SO_ActivePatternsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO_CSharpActivePatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var apInt = new Func<string, Option<int>>(s =>
            {
                int i;
                if (System.Int32.TryParse(s, out i)) return new Option<int>(i);
                return Option<int>.Empty;
            });
            var apBool = new Func<string, Option<bool>>(s =>
            {
                bool b;
                if (System.Boolean.TryParse(s, out b)) return new Option<bool>(b);
                return Option<bool>.Empty;
            });

            var testParse = new Action<string>(s =>
              {
                  var oi = apInt(s);
                  if (oi.HoldsValue)
                  {
                      Console.WriteLine($"The value is an int '{oi.Value}'");
                      return;
                  }
                  var ob = apBool(s);
                  if (ob.HoldsValue)
                  {
                      Console.WriteLine($"The value is an bool '{ob.Value}'");
                      return;
                  }
                  Console.WriteLine($"The value '{s}' is something else");
              });

            testParse("12");
            testParse("true");
            testParse("abc");

            System.Console.ReadKey();

        }
    }

}
