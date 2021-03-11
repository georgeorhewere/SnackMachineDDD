using SnackMachine.Logic;
using System;
using Xunit;

namespace SnackMachine.Tests
{
    public class MoneyUnitTestSpecs
    {
        [Fact]
        public void Sum_of_2_money_should_produce_correct_result()
        {
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            Money sum = money1 + money2;
            Assert.Equal(2, sum.OneCentCount);

        }
    }
}
