using System;
using System.Linq;
using static SnackMachine.Logic.Money;

namespace SnackMachine.Logic
{
    public sealed class SnackMachine : Entity
    {

        public Money MoneyInside { get; private set; } = None;
        public Money MoneyInTransaction { get; private set; } = None;

      

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = { OneCent, TenCent, Quarter, OneDollar, FiveDollar, TwentyDollar };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;

        }

    }
}
