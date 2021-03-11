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
            var snackMachine = new SnackMachine.Logic.SnackMachine();
            snackMachine.InsertMoney(new Money(0, 0, 0, 1, 0, 0));

            snackMachine.ReturnMoney();

            Assert.Equal(0m,snackMachine.MoneyInTransaction.Amount);

        }


    }

}
