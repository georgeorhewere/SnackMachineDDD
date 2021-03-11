using SnackMachine.Logic;
using System;
using Xunit;
using FluentAssertions;
using static SnackMachine.Logic.Money;

namespace SnackMachine.Tests
{
    public class SnackMachineUnitTestSpecs
    {
        [Fact]
        public void return_money_empties_money_in_transaction()
        {
            //Arrange
            var snackMachine = new SnackMachine.Logic.SnackMachine();            
            snackMachine.InsertMoney(OneDollar);
            
            //Act
            snackMachine.ReturnMoney();
            //Assert
            Assert.Equal(0m,snackMachine.MoneyInTransaction.Amount);
        }

        [Fact]
        public void inserted_money_goes_to_money_in_transaction()
        {
            //Arrange
            var snackMachine = new SnackMachine.Logic.SnackMachine();
            
            //Act
            snackMachine.InsertMoney(OneCent);
            snackMachine.InsertMoney(OneDollar);

            //Assert
            Assert.Equal(1.01m, snackMachine.MoneyInTransaction.Amount);

        }

        [Fact]
        public void cannot_insert_more_than_one_coin_or_note_at_a_time()
        {
            //Arrange
            var snackMachine = new SnackMachine.Logic.SnackMachine();
            //Act
            var twoCent = OneCent + OneCent;
            Action action = () => { snackMachine.InsertMoney(twoCent); };

            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void money_in_transaction_goes_to_money_inside_after_purchase()
        {
            //Arrange
            var snackMachine = new SnackMachine.Logic.SnackMachine();

            //Act
            snackMachine.InsertMoney(OneDollar);
            snackMachine.InsertMoney(OneDollar);

            snackMachine.BuySnack();

            //Assert
            //Assert.True(snackMachine.MoneyInTransaction.Equals(None));
            snackMachine.MoneyInTransaction.Should().Be(None);
            Assert.True(snackMachine.MoneyInside.Amount.Equals(2m));
        }
    }

}
