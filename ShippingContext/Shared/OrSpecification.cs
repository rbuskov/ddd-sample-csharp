namespace ShippingContext.Shared
{
    public class OrSpecification<T> : ISpecification<T>
        where T : notnull
    {
        private ISpecification<T> spec1;
        private ISpecification<T> spec2;

        public OrSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
        {
            this.spec1 = spec1;
            this.spec2 = spec2;
        }

        public bool IsSatisfiedBy(T t)
        {
            return spec1.IsSatisfiedBy(t) || spec2.IsSatisfiedBy(t);
        }
    }
}