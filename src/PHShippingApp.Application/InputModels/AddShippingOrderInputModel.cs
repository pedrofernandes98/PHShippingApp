using PHShippingApp.Domain.Entities;
using PHShippingApp.Domain.ValueObjects;

namespace PHShippingApp.Application.InputModels
{
    public class AddShippingOrderInputModel
    {
        public string Description { get; set; }

        public DeliveryAddressInputModel DeliveryAddress { get; set; }

        public decimal WeightInKg { get; set; }

        public List<ShippingServiceInputModel> Services { get; set; }

        public ShippingOrder ToEntity() => new ShippingOrder(Description, WeightInKg, DeliveryAddress.ToValueObject());
    }
}
