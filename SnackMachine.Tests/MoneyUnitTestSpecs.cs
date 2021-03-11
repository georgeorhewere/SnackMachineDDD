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
            //Arrange
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            //Act
            Money sum = money1 + money2;

            //Assert
            Assert.Equal(2, sum.OneCentCount);
            Assert.Equal(4, sum.TenCentCount);
            Assert.Equal(6, sum.QuaterCount);
            Assert.Equal(8, sum.OneDollarCount);
            Assert.Equal(10, sum.FiveDollarCount);
            Assert.Equal(12, sum.TwentyDollarCount);
        }

        [Fact]
        public void Two_money_instances_equal_if_they_contain_same_amount()
        {
            //Arrange
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            //Act

            //Assert
            Assert.Equal(money1, money2);
            Assert.True(money1.GetHashCode().Equals(money2.GetHashCode()));
        }

        [Fact]
        public void Two_money_instances_do_not_equal_if_they_contain_different_amount()
        {
            //Arrange
            Money dollar = new Money(0, 0, 0, 1, 0, 0);
            Money hundredCents = new Money(100, 0, 0, 0, 0, 0);

            //Act

            //Assert
            Assert.NotEqual(dollar, hundredCents);
            Assert.False(dollar.GetHashCode().Equals(hundredCents.GetHashCode()));
        }


    }
}
