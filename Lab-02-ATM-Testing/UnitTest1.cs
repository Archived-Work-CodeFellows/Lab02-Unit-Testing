using System;
using Lab_02_ATM;
using Xunit;

namespace Lab_02_ATM_Testing
{
    public class UnitTest1
    {
        [Fact]
        public void Withdraw1()
        {
            Assert.Equal(500, Program.WithdrawSelect(2000, 2500));
        }

        [Fact]
        public void WithdrawOver()
        {
            Assert.Equal(2500, Program.WithdrawSelect(3000 , 2500));
        }

        [Theory]
        [InlineData(2500,2500,0)]
        [InlineData(10, 2500, 2490)]
        [InlineData(100, 2500, 2400)]
        [InlineData(1250, 2500, 1250)]
        [InlineData(3000, 2500, 2500)]
        [InlineData(30000, 2500, 2500)]
        [InlineData(2501, 2500, 2500)]
        public void Withdrawals(decimal amount, decimal balance, decimal expected)
        {
            Assert.Equal(expected, Program.WithdrawSelect(amount, balance));
        }
        
        [Fact]
        public void Deposit1()
        {
            Assert.Equal(4500, Program.DepositSelect(2000, 2500));
        }

        [Fact]
        public void DepositNegative()
        {
            Assert.Equal(2500, Program.DepositSelect(-500, 2500));
        }

        [Theory]
        [InlineData(10, 2500, 2510)]
        [InlineData(200, 2500, 2700)]
        [InlineData(1000, 2500, 3500)]
        [InlineData(10000, 2500, 12500)]
        [InlineData(-1250, 2500, 2500)]
        [InlineData(-1, 2500, 2500)]
        [InlineData(0, 2500, 2500)]
        public void Deposits(decimal amount, decimal balance, decimal expected)
        {
            Assert.Equal(expected, Program.DepositSelect(amount, balance));
        }
    }
}
