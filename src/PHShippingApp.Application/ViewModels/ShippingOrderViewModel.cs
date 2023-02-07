using PHShippingApp.Domain.Entities;
using PHShippingApp.Domain.Enums;
using PHShippingApp.Domain.ValueObjects;

namespace PHShippingApp.Application.ViewModels
{
    public class ShippingOrderViewModel
    {
        public ShippingOrderViewModel(string tranckingCode, string description, DateTime postedAt, decimal weightInKg, string fullAddress)
        {
            TranckingCode = tranckingCode;
            Description = description;
            PostedAt = postedAt;
            WeightInKg = weightInKg;
            FullAddress = fullAddress;
        }

        public string TranckingCode { get; set; }

        public string Description { get; set; }

        public DateTime PostedAt { get; set; }

        public decimal WeightInKg { get; set; }

        public string FullAddress { get; set; }

        public static ShippingOrderViewModel GetFromEntity(ShippingOrder shippingOrder)
        {
            return new ShippingOrderViewModel(
                shippingOrder.TranckingCode,
                shippingOrder.Description,
                shippingOrder.PostedAt,
                shippingOrder.WeightInKg,
                $"{shippingOrder.DeliveryAddress.Street}, {shippingOrder.DeliveryAddress.Number}, {shippingOrder.DeliveryAddress.ZipCode}, {shippingOrder.DeliveryAddress.City}, {shippingOrder.DeliveryAddress.Country}");
        }

        
    }
}
