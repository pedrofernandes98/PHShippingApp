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
        //protected readonly IShippingOrderRepository _repository;

        //public ShippingOrderService(IShippingOrderRepository repository)
        //{
        //    _repository = repository;
        //}

        public Task<string> Add(AddShippingOrderInputModel addShippingOrderInputModel)
        {
            var shippingOrderEntity = addShippingOrderInputModel.ToEntity();

            var shippingServicesEntity = addShippingOrderInputModel.Services.Select(s => s.ToEntity()).ToList();

            shippingOrderEntity.SetupServices(shippingServicesEntity);

            Console.WriteLine(JsonSerializer.Serialize(shippingOrderEntity));

            return Task.FromResult(shippingOrderEntity.TranckingCode);
         }

        public Task<ShippingOrderViewModel> GetByCode(string trackingCode)
        {
            var shippingOrder = new ShippingOrder(
                "Pedido 1",
                1.3m,
                new DeliveryAddress("Rua A", "1A", "12345-678", "São Paulo", "SP", "Brasil")
            );

            return Task.FromResult(ShippingOrderViewModel.GetFromEntity(shippingOrder));
        }
    }
}
