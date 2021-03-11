using SnackMachine.Logic;
using System;
using Xunit;


namespace SnackMachine.Tests
{
    public class SnackMachineUnitTestSpecs
    {
        [Fact]
        public void return_money_empties_money_in_transaction()
        {
            //Arrange
            var snackMachine = new SnackMachine.Logic.SnackMachine();            
            snackMachine.InsertMoney(Money.OneDollar);
            
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
            snackMachine.InsertMoney(Money.OneCent);
            snackMachine.InsertMoney(Money.OneDollar);

            //Assert
            Assert.Equal(1.01m, snackMachine.MoneyInTransaction.Amount);

        }


    }

}
