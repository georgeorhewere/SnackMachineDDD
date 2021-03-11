namespace SnackMachine.Logic
{
    public sealed class Money : ValueObject<Money>
    {
        public int OneCentCount { get; set; }
        public int TenCentCount { get; set; }
        public int QuaterCount { get; set; }
        public int OneDollarCount { get; set; }
        public int FiveDollarCount { get; set; }
        public int TwentyDollarCount { get; set; }

        public Money(int oneCentCount,
            int tenCentCount,
            int quaterCount,
            int oneDollarCount,
            int fiveDollarCount,
            int twentyDollarCount)
        {
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