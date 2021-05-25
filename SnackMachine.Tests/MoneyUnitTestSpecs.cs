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

        //edge cases
        [Theory]
        [InlineData(-1,0,0,0,0,0)]
        [InlineData(0, -2, 0, 0, 0, 0)]
        [InlineData(0, 0, -3, 0, 0, 0)]
        [InlineData(0, 0, 0, -4, 0, 0)]
        [InlineData(0, 0, 0, 0, -5, 0)]
        [InlineData(0, 0, 0, 0, 0, -6)]
        public void Cannot_create_money_with_negative_value(int oneCentCount,
            int tenCentCount,
            int quaterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {

            Action action = () => new Money(oneCentCount, tenCentCount, quaterCount, oneDollarCount, fiveDollarCount, twentyDollarCount);
            Assert.Throws<InvalidOperationException>(action);

        }
        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0,0)]
        [InlineData(1, 0, 0, 0, 0, 0,0.01)]
        [InlineData(1, 2, 0, 0, 0, 0,0.21)]
        [InlineData(1, 2, 3, 0, 0, 0,0.96)]
        [InlineData(1, 2, 3, 4, 0, 0, 4.96)]
        [InlineData(1, 2, 3, 4, 5, 0, 29.96)]
        [InlineData(1, 2, 3, 4, 5, 6, 149.96)]
        [InlineData(11, 0, 0, 0, 0, 0, 0.11)]
        [InlineData(110, 0, 0, 0, 100, 0, 501.1)]
        public void amount_is_claculated_correctly(int oneCentCount,
           int tenCentCount,
           int quaterCount,
           int oneDollarCount,
           int fiveDollarCount,
           int twentyDollarCount,
           decimal expectedAmount)
        {
            Money money = new Money(oneCentCount, tenCentCount, quaterCount, oneDollarCount, fiveDollarCount, twentyDollarCount);
            Assert.True(money.Amount.Equals(expectedAmount));
        }
        [Fact]
        public void subtraction_of_two_moneys_produces_correct_result()
        {

            //Arrange
            Money money1 = new Money(10, 10, 10, 10, 10, 10);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            //Act
            Money result = money1 - money2;
            //Assert
            Assert.Equal(9, result.OneCentCount);
            Assert.Equal(8, result.TenCentCount);
            Assert.Equal(7, result.QuaterCount);
            Assert.Equal(6, result.OneDollarCount);
            Assert.Equal(5, result.FiveDollarCount);
            Assert.Equal(4, result.TwentyDollarCount);
        }
        [Fact]
        public void cannot_subtract_more_than_exists()
        {
            //Arrange
            Money money1 = new Money(0, 1, 0, 0, 0, 0);
            Money money2 = new Money(1, 0, 0, 0, 0, 0);

            //Act
            Action action = () => { Money money = money1 - money2; };
            
            //Assert
            Assert.Throws<InvalidOperationException>(action);
            
        }

        [Theory]
        [InlineData(1, 0, 0, 0, 0, 0, "¢1")]
        [InlineData(1, 2, 0, 0, 0, 0, "¢21")]
        [InlineData(1, 2, 3, 0, 0, 0, "¢96")]
        [InlineData(0, 0, 0, 3, 0, 0, "$3")]
        public void should_return_money_symbol_on_to_string(int oneCentCount,
           int tenCentCount,
           int quaterCount,
           int oneDollarCount,
           int fiveDollarCount,
           int twentyDollarCount,
           string expectedResult)
        {

            Money money = new Money(oneCentCount, tenCentCount, quaterCount, oneDollarCount, fiveDollarCount, twentyDollarCount);
            Assert.True(money.ToString().Equals(expectedResult));

        }
    }
 


    
}
