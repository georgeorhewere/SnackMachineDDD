namespace SnackMachine.Logic
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        protected abstract int GetHashCodeCore();


    }
}