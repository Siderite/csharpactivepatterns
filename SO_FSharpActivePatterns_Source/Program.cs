using Microsoft.FSharp.Core;
using System;

[CompilationMapping(SourceConstructFlags.Module)]
public static class Program
{
    [EntryPoint]
    public static int main(string[] argv)
    {
        FSharpFunc<string, FSharpOption<int>> func = new |Int|_|@10();
        FSharpFunc<string, FSharpOption<bool>> func2 = new |Bool|_|@16();
        FSharpFunc<string, Unit> func3 = new testParse@22(func, func2);
        func3.Invoke("12");
        func3.Invoke("true");
        func3.Invoke("abc");
        ConsoleKeyInfo info2 = Console.ReadKey();
        return 0;
    }

    [Serializable]
    internal class |Bool|_|@16 : FSharpFunc<string, FSharpOption<bool>>
    {
        internal |Bool|_|@16()
        {
        }

        public override FSharpOption<bool> Invoke(string str)
        {
            bool flag = false;
            Tuple<bool, bool> tuple = new Tuple<bool, bool>(bool.TryParse(str, out flag), flag);
            if (!tuple.Item1)
            {
                return null;
            }
            return FSharpOption<bool>.Some(tuple.Item2);
        }
    }

    [Serializable]
    internal class |Int|_|@10 : FSharpFunc<string, FSharpOption<int>>
    {
        internal |Int|_|@10()
        {
        }

        public override FSharpOption<int> Invoke(string str)
        {
            int num = 0;
            Tuple<bool, int> tuple = new Tuple<bool, int>(int.TryParse(str, out num), num);
            if (!tuple.Item1)
            {
                return null;
            }
            return FSharpOption<int>.Some(tuple.Item2);
        }
    }

    [Serializable]
    internal class testParse@22 : FSharpFunc<string, Unit>
    {
        public FSharpFunc<string, FSharpOption<bool>> |Bool|_|;
        public FSharpFunc<string, FSharpOption<int>> |Int|_|;

        internal testParse@22(FSharpFunc<string, FSharpOption<int>> |Int|_|, FSharpFunc<string, FSharpOption<bool>> |Bool|_|)
        {
            this.|Int|_| = |Int|_|;
            this.|Bool|_| = |Bool|_|;
        }

        public override Unit Invoke(string str)
        {
            string str2 = str;
            FSharpOption<int> option = this.|Int|_|.Invoke(str2);
            if (option != null)
            {
                int num = option.get_Value();
                FSharpFunc<int, Unit> func = ExtraTopLevelOperators.PrintFormatLine<FSharpFunc<int, Unit>>(new PrintfFormat<FSharpFunc<int, Unit>, TextWriter, Unit, Unit, int>("The value is an int '%i'"));
                int num2 = num;
                return func.Invoke(num2);
            }
            FSharpOption<bool> option2 = this.|Bool|_|.Invoke(str2);
            if (option2 != null)
            {
                bool flag = option2.get_Value();
                FSharpFunc<bool, Unit> func2 = ExtraTopLevelOperators.PrintFormatLine<FSharpFunc<bool, Unit>>(new PrintfFormat<FSharpFunc<bool, Unit>, TextWriter, Unit, Unit, bool>("The value is a bool '%b'"));
                bool flag2 = flag;
                return func2.Invoke(flag2);
            }
            FSharpFunc<string, Unit> func3 = ExtraTopLevelOperators.PrintFormatLine<FSharpFunc<string, Unit>>(new PrintfFormat<FSharpFunc<string, Unit>, TextWriter, Unit, Unit, string>("The value '%s' is something else"));
            string str3 = str;
            return func3.Invoke(str3);
        }
    }
}

