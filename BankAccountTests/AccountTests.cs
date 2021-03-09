﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize]//Run code before EACH test
        public void Initialize()
        {
            acc = new Account();
        }
        

        [TestMethod]
        //TestCategory("Deposit")]
        [DataRow(10_000)]
        [DataRow(11234.12)]
        [DataRow(10000.01)]
        [DataRow(double.MaxValue)]
        public void Deposit_TooLarge_ThrowsArgumentException(double tooLargeDeposit)
        {

            Assert.ThrowsException<ArgumentException>
                (
                    () => acc.Deposite(tooLargeDeposit)
                );
        }

        [TestMethod()]
        //[TestCategory("Deposit")]
        [DataRow(100)]
        [DataRow(9999.99)]
        [DataRow(.01)]
        public void Deposit_PositiveAmount_AddsToBalance(double initialDeposit)
        {
            // AAA - Arrange Act Assert

            // Arrange - Creating variables/object
            const double startBalance = 0;

            // Act = Execute method under test
            acc.Deposite(initialDeposit);

            //Assert - Check a condition
            Assert.AreEqual(startBalance + initialDeposit, acc.Balance);
        }

        [TestMethod]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance()
        {
            // Arrange
            double initialBalance = 0;
            double depositAmount = 10.55;

            //Act
            double newBalance = acc.Deposite(depositAmount);

            //Assert
            double expectedBalance = initialBalance + depositAmount;
            Assert.AreEqual(expectedBalance, newBalance);
        }

        [TestMethod]
        public void Deposit_MultipleAmounts_ReturnsAccumulatedBalance()
        {
            //Arrange
            double deposit1 = 10;
            double deposit2 = 25;
            double expectedBalance = deposit1 + deposit2;
            //Act
            acc.Deposite(deposit1);
            double finalBalance = acc.Deposite(deposit2);
            //Assert
            Assert.AreEqual(expectedBalance, finalBalance);
        }

        [TestMethod]
        public void Deposit_NegativeAmounts_ThrowsArgumentException()
        {
            double negativeDeposit = -1;

            // Assert => Act
            Assert.ThrowsException<ArgumentException>(
                    () => acc.Deposite(negativeDeposit)
                    );
        }

        [TestMethod]
        [DataRow(100, 50)]
        [DataRow(50, 50)]
        [DataRow(9.99, 9.99)]
        public void Withdraw_PositiveAmount_SubtractsFromBalance(double initialDeposit, double withdrawAmount)
        {
            double expectedBalance = initialDeposit - withdrawAmount;

            acc.Deposite(initialDeposit);
            acc.Withdraw(withdrawAmount);

            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        public void Withdraw_MoreThanBalance_ThrowsArgumentException()
        {
            //double initialBalance = 0;
            //An account created with the default constructor has a 0 balance
            Account myAccount = new Account();
            double withdrawAmount = 1000;
            Assert.ThrowsException<ArgumentException>(() => myAccount.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Withdraw_NegativeAmount_ThrowsArgumentException()
        {
            Assert.ThrowsException < ArgumentException > (() => acc.Withdraw(-1));
        }
    }
}