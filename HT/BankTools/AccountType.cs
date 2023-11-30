using System;
using System.Collections.Generic;

namespace BankTools
{
    public class AccountType
    {
        #region privates
        private static ulong index;
        private decimal balance;
        private ulong accountNumber;
        private BankAccountType accountType;
        private readonly Queue<BankTransaction> trans = new Queue<BankTransaction>();
        #endregion

        /// <exception cref="ArgumentException">Negative sum</exception>
        public void TransferMoney(AccountType from, decimal sum)
        {
            if (sum < 0)
            {
                throw new ArgumentException("Negative transfer sum");
            }

            if (from.balance > sum)
            {
                from.Withdraw(sum);
                PutOn(sum);
            }
            else
            {
                Console.WriteLine($"{from.accountNumber:0000 0000 0000 0000}: There is not enough money to withdraw {sum.ToString("C2")}");
            }

        }

        /// <summary>
        /// Gets the account number.
        /// </summary>
        /// <returns>The account number.</returns>
        public ulong GetAccountNumber()
        {
            return accountNumber;
        }

        /// <summary>
        /// Gets the type of the account.
        /// </summary>
        /// <returns>The account type.</returns>
        public BankAccountType GetAccountType()
        {
            return accountType;
        }

        /// <summary>
        /// Bank account types.
        /// </summary>
        public enum BankAccountType
        {
            Saving,
            Current
        }

        /// <summary>
        /// Withdraw the money fromaccount
        /// </summary>
        /// <param name="sum">The money</param>
        /// <exception cref="ArgumentException">Negative sum</exception>
        public void Withdraw(decimal sum)
        {
            if (sum < 0)
            {
                throw new ArgumentException("Negative sum to withdraw");
            }

            if (balance > sum)
            {
                balance -= sum;
                Dispose(new BankTransaction(sum));
                Console.WriteLine($"From {accountNumber:0000 0000 0000 0000} withdrawed {sum} ₽");
            }
            else
            {
                Console.WriteLine($"{accountNumber:0000 0000 0000 0000}: There is not enough money to withdraw {sum.ToString("C2")}");
            }
        }

        /// <summary>
        /// Puts on the money.
        /// </summary>
        /// <param name="sum">The money</param>
        /// <exception cref="ArgumentException">Negative sum</exception>
        public void PutOn(decimal sum)
        {
            if (sum < 0)
            {
                throw new ArgumentException("Negative sum to put on");
            }
            balance += sum;
            Dispose(new BankTransaction(sum));
            Console.WriteLine($"{accountNumber:0000 0000 0000 0000} was put on with {sum} ₽");
        }

        private void Dispose(BankTransaction transaction)
        {
            GC.SuppressFinalize(this);
            trans.Enqueue(transaction);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tymakov.AccountType"/> class.
        /// </summary>
        /// <param name="accountType">Type of the account</param>
        internal AccountType(BankAccountType accountType)
        {
            balance = 0;
            accountNumber = index++;
            this.accountType = accountType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tymakov.AccountType"/> class.
        /// </summary>
        /// <param name="sum">Sum.</param>
        internal AccountType(int sum)
        {
            PutOn(sum);
            accountNumber = index++;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tymakov.AccountType"/> class.
        /// </summary>
        /// <param name="accountType">Type of the account</param>
        internal AccountType(BankAccountType accountType, int sum)
        {
            PutOn(sum);
            accountNumber = index++;
            this.accountType = accountType;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Tymakov.AccountType"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Tymakov.AccountType"/>.</returns>
        public override string ToString()
        {
            return $"Account №{accountNumber:0000 0000 0000 0000}\n\tAccount type: {accountType.ToString()}\n\tBalance: {balance:C2}";
        }
    }
}