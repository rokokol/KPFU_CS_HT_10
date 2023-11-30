using System;
using System.Collections.Generic;

namespace BankTools
{
    public class AccountType
    {
        public static bool operator ==(AccountType first, AccountType second)
        {
            return first.Equals(second);
        }
        
        public static bool operator !=(AccountType first, AccountType second)
        {
            return !first.Equals(second);
        }
        
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

        protected bool Equals(AccountType other)
        {
            return balance == other.balance && accountNumber == other.accountNumber && accountType == other.accountType && Equals(trans, other.trans);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AccountType)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = balance.GetHashCode();
                hashCode = (hashCode * 397) ^ accountNumber.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)accountType;
                hashCode = (hashCode * 397) ^ (trans != null ? trans.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}