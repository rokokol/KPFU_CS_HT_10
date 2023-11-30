﻿using System;

namespace MathTools
{
    /// <summary>
    /// The rational number from the Q set 
    /// </summary>
    public class RationalNumber
    {
        public ulong IntegerPart { get; set; }
        public ulong Numerator { get; set; }
        public ulong Denominator { get; set; }
        public bool IsPositive { get; set; }

        /// <summary>
        /// Find the Greatest Common Delimiter
        /// </summary>
        /// <param name="m">m</param>
        /// <param name="n">n</param>
        /// <returns>GCD of m and n</returns>
        private static ulong Gcd(ulong m, ulong n)
        {
            while (m != 0 && n != 0)
            {
                if (m > n)
                {
                    m %= n;
                }
                else
                {
                    n %= m;
                }
            }
            return checked(m + n);
        }
        
        /// <summary>
        /// Converts to correct form
        /// </summary>
        public void Simplify()
        {
            if (Numerator > Denominator)
            {
                IntegerPart = Numerator / Denominator;
                Numerator %= Denominator;
            }

            var gcd = Gcd(Numerator, Denominator);
            
            Numerator /= gcd;
            Denominator /= gcd;
        }

        /// <summary>
        /// Summing of two rational numbers
        /// </summary>
        /// <param name="a">The rational number</param>
        /// <param name="b">The rational number</param>
        /// <returns>The sum of two rational numbers</returns>
        public static RationalNumber Sum(RationalNumber a, RationalNumber b)
        {
            checked
            {
                ulong lcm, newNumeratorA, newNumeratorB, newNumerator, newIntegerPartA, newIntegerPartB, newIntegerPart;
                bool newSign;
                lcm = a.Denominator * b.Denominator / Gcd(a.Denominator, b.Denominator);
                newNumeratorA = (lcm / a.Denominator) * (a.Numerator + a.IntegerPart * a.Denominator);
                newNumeratorB = (lcm / b.Denominator) * (b.Numerator + b.IntegerPart * b.Denominator);
                newIntegerPartA = 0;
                newIntegerPartB = 0;
                
                if (newNumeratorA > lcm)
                {
                    newIntegerPartA = newNumeratorA / lcm;
                    newNumeratorA %= lcm;
                }
                
                if (newNumeratorB > lcm)
                {
                    newIntegerPartB = newNumeratorB / lcm;
                    newNumeratorB %= lcm;
                }
                
                if (a.IsPositive == b.IsPositive)
                {
                    newIntegerPart = newIntegerPartA + newIntegerPartB;
                    newNumerator = newNumeratorA + newNumeratorB;
                    newSign = a.IsPositive;
                }
                else
                {
                    newIntegerPart = Math.Max(newIntegerPartA, newIntegerPartB) - Math.Min(newIntegerPartA, newIntegerPartB);
                    newNumerator = Math.Max(newNumeratorA, newNumeratorB) - Math.Min(newNumeratorA, newNumeratorB);
                    newSign = newNumeratorA > newNumeratorB ? a.IsPositive : b.IsPositive;
                }
                return new RationalNumber(newIntegerPart, newNumerator, lcm, newSign);
            }
        }

        /// <summary>
        /// Differencing of two rational numbers
        /// </summary>
        /// <param name="a">The rational number</param>
        /// <param name="b">The rational number</param>
        /// <returns>The difference of a and b</returns>
        public static RationalNumber Difference(RationalNumber a, RationalNumber b)
        {
            RationalNumber negativeB = new RationalNumber(b.IntegerPart, b.Numerator, b.Denominator, !b.IsPositive);
            return Sum(a, negativeB);
        }

        /// <summary>
        /// Production of two rational numbers
        /// </summary>
        /// <param name="a">The rational number</param>
        /// <param name="b">The rational number</param>
        /// <returns>The production of a and b</returns>
        public static RationalNumber Multiply(RationalNumber a, RationalNumber b)
        {
            ulong newNumerator, newDenominator;
            newNumerator = (a.Numerator + a.IntegerPart * a.Denominator) *
                           (b.Numerator + b.IntegerPart * b.Denominator);
            newDenominator = a.Denominator * b.Denominator;
            
            return new RationalNumber(newNumerator, newDenominator, a.IsPositive == b.IsPositive);
        }

        /// <summary>
        /// Division of two rational numbers
        /// </summary>
        /// <param name="a">The rational number</param>
        /// <param name="b">The rational number</param>
        /// <returns>The division of a and b</returns>
        public static RationalNumber Divide(RationalNumber a, RationalNumber b)
        {
            ulong newNumerator = b.Denominator;
            b.Denominator = b.Numerator + b.IntegerPart * b.Denominator;
            b.Numerator = newNumerator;
            return Multiply(a, b);
        }
        
        public override string ToString()
        {
            var sign = IsPositive ? "" : "-";
            var secondSign = IsPositive ? "+" : "-";
            var integerPart = IntegerPart == 0 ? "" : $"{IntegerPart} {secondSign} ";
            return $"{sign}{integerPart}{Numerator}/{Denominator}";
        }

        /// <summary>
        /// The rational number from the Q set 
        /// </summary>
        /// <param name="numerator">The numerator</param>
        /// <param name="denominator">The denominator</param>
        /// <param name="isPositive">Is positive or not</param>
        public RationalNumber(ulong numerator, ulong denominator, bool isPositive)
        {
            Numerator = numerator;
            Denominator = denominator;
            IsPositive = isPositive;
            Simplify();
        }

        protected bool Equals(RationalNumber other)
        {
            Simplify();
            other.Simplify();
            return IntegerPart == other.IntegerPart && Numerator == other.Numerator && Denominator == other.Denominator && IsPositive == other.IsPositive;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RationalNumber)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = IntegerPart.GetHashCode();
                hashCode = (hashCode * 397) ^ Numerator.GetHashCode();
                hashCode = (hashCode * 397) ^ Denominator.GetHashCode();
                hashCode = (hashCode * 397) ^ IsPositive.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// The rational number from the Q set 
        /// </summary>
        /// <param name="integerPart">The integer part of a number</param>
        /// <param name="numerator">The numerator</param>
        /// <param name="denominator">The denominator</param>
        /// <param name="isPositive">Is positive or not</param>
        public RationalNumber(ulong integerPart, ulong numerator, ulong denominator, bool isPositive)
        {
            IntegerPart = integerPart;
            Numerator = numerator;
            Denominator = denominator;
            IsPositive = isPositive;
            Simplify();
        }

        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            return Sum(a, b);
        }
        
        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            return Difference(a, b);
        }
        
        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            return Multiply(a, b);
        }
        
        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            return Divide(a, b);
        }
        
        public static bool operator ==(RationalNumber a, RationalNumber b)
        {
            return !ReferenceEquals(null, a) && a.Equals(b);
        }
        
        public static bool operator !=(RationalNumber a, RationalNumber b)
        {
            return !ReferenceEquals(null, a) && !a.Equals(b);
        }
    }
}
