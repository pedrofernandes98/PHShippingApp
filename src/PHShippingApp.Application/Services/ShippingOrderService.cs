using PHShippingApp.Application.InputModels;
using PHShippingApp.Application.Services.Interfaces;
using PHShippingApp.Application.ViewModels;
using PHShippingApp.Domain.Entities;
using PHShippingApp.Domain.Interfaces.Repositories;
using PHShippingApp.Domain.ValueObjects;
using System.Text.Json;

namespace PHShippingApp.Application.Services
{
    public class ShippingOrderService : IShippingOrderService
    {
        protected readonly IShippingOrderRepository _repository;

        public ShippingOrderService(IShippingOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Add(AddShippingOrderInputModel addShippingOrderInputModel)
        {
            var shippingOrderEntity = addShippingOrderInputModel.ToEntity();

            var shippingServicesEntity = addShippingOrderInputModel.Services.Select(s => s.ToEntity()).ToList();

            shippingOrderEntity.SetupServices(shippingServicesEntity);

            await _repository.AddAsync(shippingOrderEntity);

            return shippingOrderEntity.TranckingCode;
         }

        public async Task<ShippingOrderViewModel> GetByCode(string trackingCode)
        {
            var shippingOrder = await _repository.GetByCodeAsync(trackingCode);

            return ShippingOrderViewModel.GetFromEntity(shippingOrder);
        }
    }
}
