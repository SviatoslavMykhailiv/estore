using estore.domain.Models.Abstraction;

namespace estore.domain.Models
{
    public class Product : IModelWithIdentifier
    {
        public long Id { get; set; }
    }
}
