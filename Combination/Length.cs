
using System;
using System.Numerics;


namespace Combination
{
    public class Length : IComparable<Length>
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

        public static implicit operator Length(int value)
        {
            return new Length(value);
        }

        public static Length operator *(BigInteger left, Length right)
        {
            return left * right.Value;
        }

        public static Length operator *(int left, Length right)
        {
            return left * right.Value;
        }

        public static Length operator *(Length left, BigInteger right)
        {
            return left.Value * right;
        }

        public static Length operator *(Length left, int right)
        {
            return left.Value * right;
        }

        public static Length operator +(Length left, Length right)
        {
            return left.Value + right.Value;
        }

        public static Length operator ++(Length length)
        {
            return length+new Length(1);
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

        public int CompareTo(Length otherLength)
        {
                return this.Value.CompareTo(otherLength.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }


        public override bool Equals(object obj)
        {
            if (obj is Length otherLength)
            {
                return otherLength == this;
            }

            return false;
        }
        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
