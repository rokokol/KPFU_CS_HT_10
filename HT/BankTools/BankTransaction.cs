using System;

namespace BankTools
{
    /// <summary>
    /// Bank transaction class.
    /// </summary>
    public class BankTransaction
    {
        /// <summary>
        /// Transaction's time
        /// </summary>
        public readonly DateTime time = DateTime.Now;
        public readonly decimal sum;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tymakov.BankTransaction"/> class.
        /// </summary>
        /// <param name="sum">Sum.</param>
        public BankTransaction(decimal sum)
        {
            this.sum = sum;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Tymakov.BankTransaction"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Tymakov.BankTransaction"/>.</returns>
        public override string ToString()
        {
            return $"A transaction with {sum:C2}";
        }
    }
}