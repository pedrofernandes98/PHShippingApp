using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace PHShippingApp.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
