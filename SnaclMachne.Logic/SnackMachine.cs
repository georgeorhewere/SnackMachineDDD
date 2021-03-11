using System;
using System.Linq;

namespace SnackMachine.Logic
{
    public sealed class SnackMachine : Entity
    {

        public Money MoneyInside { get; private set; } = Money.None;
        public Money MoneyInTransaction { get; private set; } = Money.None;

      

        public void InsertMoney(Money money)
        {
            Money[] coinsAndNotes = { Money.OneCent, Money.TenCent, Money.Quarter, Money.OneDollar, Money.FiveDollar, Money.TwentyDollar };
            if (!coinsAndNotes.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = Money.None;
        }

        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = Money.None;

        }

    }
}
