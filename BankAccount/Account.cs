using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single checking account
    /// </summary>
    class Account
    {
        private double _balance;

        /// <summary>
        /// Deposite the amount in the bank account
        /// and returns the new balance
        /// </summary>
        /// <param name="amt">The amount to deposite</param>
        public double Deposite(double amt)
        {
            _balance += amt;
            return _balance;
        }

        /// <summary>
        /// Get the current balance
        /// </summary>
        public double Balance
        {
            get
            {
                return _balance;
            }
        }

        public void Withdraw(double amt)
        {

        }
    }
}
