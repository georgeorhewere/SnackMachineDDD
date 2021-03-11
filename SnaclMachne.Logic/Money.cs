using System;

namespace SnackMachine.Logic
{
    public sealed class Money : ValueObject<Money>
    {
        public int OneCentCount { get; }
        public int TenCentCount { get; }
        public int QuaterCount { get;  }
        public int OneDollarCount { get; }
        public int FiveDollarCount { get; }
        public int TwentyDollarCount { get; }
        public decimal Amount  => OneCentCount * 0.01m + 
                     TenCentCount * 0.10m + 
                     QuaterCount * 0.25m +
                     OneDollarCount +
                     FiveDollarCount * 5 + 
                     TwentyDollarCount * 20;

        public Money(int oneCentCount,
            int tenCentCount,
            int quaterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {

            if (oneCentCount < 0)
                throw new InvalidOperationException();
            if (tenCentCount < 0)
                throw new InvalidOperationException();
            if (quaterCount < 0)
                throw new InvalidOperationException();
            if (oneDollarCount < 0)
                throw new InvalidOperationException();
            if (fiveDollarCount < 0)
                throw new InvalidOperationException();
            if (twentyDollarCount < 0)
                throw new InvalidOperationException();

            OneCentCount = oneCentCount;
            TenCentCount = tenCentCount;
            QuaterCount = quaterCount;
            OneDollarCount = oneDollarCount;
            FiveDollarCount = fiveDollarCount;
            TwentyDollarCount = twentyDollarCount;
        }

        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(money1.OneCentCount + money2.OneCentCount,
                                  money1.TenCentCount + money2.TenCentCount,
                                  money1.QuaterCount + money2.QuaterCount,
                                  money1.OneDollarCount + money2.OneDollarCount,
                                  money1.FiveDollarCount + money2.FiveDollarCount,
                                  money1.TwentyDollarCount + money2.TwentyDollarCount);
            return sum;

        }
        public static Money operator -(Money money1, Money money2)
        {
            Money subtract = new Money(money1.OneCentCount - money2.OneCentCount,
                                  money1.TenCentCount - money2.TenCentCount,
                                  money1.QuaterCount - money2.QuaterCount,
                                  money1.OneDollarCount - money2.OneDollarCount,
                                  money1.FiveDollarCount - money2.FiveDollarCount,
                                  money1.TwentyDollarCount - money2.TwentyDollarCount);
            return subtract;

        }

        protected override bool EqualsCore(Money other)
        {
            // check equality of eachof the properties
            return OneCentCount == other.OneCentCount &&
                   TenCentCount == other.TenCentCount &&
                   QuaterCount == other.QuaterCount &&
                   OneDollarCount == other.OneDollarCount &&
                   FiveDollarCount == other.FiveDollarCount &&
                   TwentyDollarCount == other.TwentyDollarCount;

        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = OneCentCount;
                hashCode = (hashCode * 397) ^ TenCentCount;
                hashCode = (hashCode * 397) ^ QuaterCount;
                hashCode = (hashCode * 397) ^ OneDollarCount;
                hashCode = (hashCode * 397) ^ FiveDollarCount;
                hashCode = (hashCode * 397) ^ TwentyDollarCount;
                return hashCode;
            }
        }
    }
}