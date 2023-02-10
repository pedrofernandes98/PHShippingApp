using MongoDB.Driver;
using PHShippingApp.Domain.Entities;

namespace PHShippingApp.Infra
{
    public class DbSeed
    {
        private readonly IMongoCollection<ShippingService> _collection;

        private List<ShippingService> _shippingServices = new List<ShippingService>()
        {
            new ShippingService("Envio estadual", 3.75m, 12),
            new ShippingService("Envio internacional", 5.25m, 15),
            new ShippingService("Caixa tamanho P", 0, 5)
        };

        public DbSeed(IMongoDatabase db)
        {
            _collection = db.GetCollection<ShippingService>("services");
        }

        public void Populate()
        {
            if (_collection.CountDocuments(d => true) == 0)
                _collection.InsertManyAsync(_shippingServices);
        }
    }
}
