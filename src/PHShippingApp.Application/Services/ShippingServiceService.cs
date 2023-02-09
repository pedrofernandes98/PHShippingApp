using PHShippingApp.Application.Services.Interfaces;
using PHShippingApp.Application.ViewModels;
using PHShippingApp.Domain.Entities;
using PHShippingApp.Domain.Interfaces.Repositories;

namespace PHShippingApp.Application.Services
{
    public class ShippingServiceService : IShippingServiceService
    {
        private readonly IShippingServiceRepository _repository;

        public ShippingServiceService(IShippingServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ShippingServiceViewModel>> GetAll()
        {
            var shippingServices = await _repository.GetAllServicesAsync();

            return shippingServices
                    .Select(s => new ShippingServiceViewModel(s.Id, s.Title, s.PricePerKg, s.FixedPrice))
                    .ToList();
        }
    }
}
