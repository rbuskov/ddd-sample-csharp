namespace ShippingContext.Shared
{
    public interface ISpecification<T>
        where T : notnull
    {
        bool IsSatisfiedBy(T t);

        public ISpecification<T> And(ISpecification<T> specification) 
        {
            return new AndSpecification<T>(this, specification);
        }

        public ISpecification<T> Or(ISpecification<T> specification) 
        {
            return new OrSpecification<T>(this, specification);
        }

        public ISpecification<T> Not() 
        {
            return new NotSpecification<T>(this);
        }    
    }
}