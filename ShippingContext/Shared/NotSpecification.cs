namespace ShippingContext.Shared
 {
     public class NotSpecification<T> : ISpecification<T>
        where T : notnull
     {
         private ISpecification<T> spec;
 
         public NotSpecification(ISpecification<T> spec)
         {
             this.spec = spec;
         }

         public bool IsSatisfiedBy(T t)
         {
             return !spec.IsSatisfiedBy(t);
         }
     }
 }