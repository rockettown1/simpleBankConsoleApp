using System;
using Xunit;
using BankLibrary;


namespace BankingTests
{
    public class UnitTest1
    {
       

        [Fact]
        public void CantBeOverdrawn()
        {
            var account = new BankAccount("John", 1000);
            Assert.Throws<InvalidOperationException>(
                () => account.MakeWithdrawal(1500, DateTime.Now, "Attemp to overdraw")
            );
        }

        [Fact]
        public void NeedMoneyToStart()
        {
           
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new BankAccount("John", -55)
                );
        }
    }
}
