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
            snackMachine.InsertMoney(Money.OneDollar);

            snackMachine.ReturnMoney();

            Assert.Equal(0m,snackMachine.MoneyInTransaction.Amount);

        }


    }

}
