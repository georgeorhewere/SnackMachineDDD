using System;

namespace SnackMachine.Logic
{
    public sealed class SnackMachine : Entity
    {

        public Money MoneyInside { get; private set; } = Money.None;
        public Money MoneyInTransaction { get; private set; } = Money.None;

      

        public void InsertMoney(Money money)
        {
            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = Money.None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            // MoneyInTransaction = 0;

        }

    }
}
