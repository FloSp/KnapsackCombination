
using System.Numerics;


namespace Combination
{
    public class Length
    {
        public BigInteger Value { get; }


        private Length(BigInteger value)
        {
            this.Value = value;
        }

        public static implicit operator Length(BigInteger value)
        {
            return new Length(value);
        }

        public static Length operator *(BigInteger left, Length right)
        {
            return left * right.Value;
        }

        public static Length operator *(Length left, BigInteger right)
        {
            return left.Value * right;
        }

        public static Length operator +(Length left, Length right)
        {
            return left.Value + right.Value;
        }

        public static Length operator -(Length left, Length right)
        {
            return left.Value - right.Value;
        }

        public static BigInteger operator /(Length left, Length right)
        {
            return left.Value / right.Value;
        }

        public static bool operator <=(Length left, Length right)
        {
            return left.Value <= right.Value;
        }

        public static bool operator >=(Length left, Length right)
        {
            return left.Value >= right.Value;
        }

        public static bool operator <(Length left, Length right)
        {
            return left.Value < right.Value;
        }

        public static bool operator >(Length left, Length right)
        {
            return left.Value >= right.Value;
        }

        public static bool operator ==(Length left, Length right)
        {
            return left >= right && left <= right;
        }

        public static bool operator !=(Length left, Length right)
        {
            return !(left == right);
        }
    }
}
