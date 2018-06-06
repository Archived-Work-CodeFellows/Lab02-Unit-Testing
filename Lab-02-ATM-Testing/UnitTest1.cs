using System;
using Lab_02_ATM;
using Xunit;

namespace Lab_02_ATM_Testing
{
    public class UnitTest1
    {
        [Fact]
        public void withdraw1()
        {
            Assert.Equal(500, Program.withdrawSelect(2000, 2500));
        }

        [Fact]
        public void withdrawOver()
        {
            Assert.Equal(2500, Program.withdrawSelect(3000 , 2500));
        }

        [Theory]
        [InlineData(2500,2500,0)]
        [InlineData(10, 2500, 2490)]
        [InlineData(100, 2500, 2400)]
        [InlineData(1250, 2500, 1250)]
        public void withdrawals(decimal amount, decimal balance, decimal expected)
        {
            Assert.Equal(expected, Program.withdrawSelect(amount, balance));
        }
    }
}
