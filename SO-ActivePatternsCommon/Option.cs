using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO_ActivePatternsCommon
{
    public class Option<T>
    {
        private static Option<T> _empty;

        public Option(T value)
        {
            this.HoldsValue = true;
            this.Value = value;
        }

        public static Func<TInput, Option<T>> From<TInput>(Func<TInput, Option<T>> f)
        {
            return f;
        }

        private Option()
        {
            this.HoldsValue = false;
        }

        public static Option<T> Empty
        {
            get
            {
                if (_empty == null) _empty = new Option<T>();
                return _empty;
            }
        }

        public override bool Equals(object obj)
        {
            var o = obj as Option<T>;
            if (o == null) return false;
            return o.HoldsValue == this.HoldsValue && object.Equals(o.Value, this.Value);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 57;
                hash = hash * 31 + HoldsValue.GetHashCode();
                if (!object.Equals(Value, default(T)))
                {
                    hash = hash * 31 + Value.GetHashCode();
                }
                return hash;
            }
        }

        public override string ToString()
        {
            return HoldsValue ? "Option<" + typeof(T).Name + ">.Empty" : "[" + Value.ToString() + "]";
        }

        public bool HoldsValue { get; private set; }
        public T Value { get; private set; }
    }
}
