using System;

namespace SO_ActivePatternsCommon
{
    public static class FluidFunc
    {
        public static FluidFunc<TInput> Match<TInput>(TInput value)
        {
            return FluidFunc<TInput>.With(value);
        }

        public static Func<TInput, Tuple<bool, TResult>> From<TInput, TResult>(Func<TInput, Tuple<bool, TResult>> func)
        {
            return func;
        }
    }

    public class FluidFunc<TInput>
    {
        private TInput _value;
        private static FluidFunc<TInput> _noOp;
        private bool _isNoop;

        public static FluidFunc<TInput> NoOp
        {
            get
            {
                if (_noOp == null) _noOp = new FluidFunc<TInput>();
                return _noOp;
            }
        }

        private FluidFunc()
        {
            this._isNoop = true;
        }

        private FluidFunc(TInput value)
        {
            this._value = value;
        }

        public static FluidFunc<TInput> With(TInput value)
        {
            return new FluidFunc<TInput>(value);
        }

        public FluidFunc<TInput> With<TNew>(Func<TInput, Option<TNew>> func, Action<TNew> action)
        {
            if (this._isNoop)
            {
                return this;
            }
            var result = func(_value);
            if (result.HoldsValue)
            {
                action(result.Value);
                return FluidFunc<TInput>.NoOp;
            }
            return new FluidFunc<TInput>(_value);
        }

        public FluidFunc<TInput> With<TNew>(Func<TInput, Tuple<bool,TNew>> func, Action<TNew> action)
        {
            if (this._isNoop)
            {
                return this;
            }
            var result = func(_value);
            if (result.Item1)
            {
                action(result.Item2);
                return FluidFunc<TInput>.NoOp;
            }
            return new FluidFunc<TInput>(_value);
        }

        public void Else(Action<TInput> action)
        {
            if (this._isNoop) return;

            action(_value);
        }

    }
}