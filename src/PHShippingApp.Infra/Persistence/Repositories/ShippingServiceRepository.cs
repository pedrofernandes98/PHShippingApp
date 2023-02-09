using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PHShippingApp.Domain.Entities;
using PHShippingApp.Domain.Interfaces.Repositories;

namespace PHShippingApp.Infra.Persistence.Repositories
{
    public class ShippingServiceRepository : IShippingServiceRepository
    {
        private readonly IMongoCollection<ShippingService> _collection;

        public ShippingServiceRepository(IMongoDatabase db)
        {
            _collection = db.GetCollection<ShippingService>("shipping-services");
        }

        public async Task<List<ShippingService>> GetAllServicesAsync()
        {
            return await _collection.Find(d => true).ToListAsync();
        }
    }
}
