using PHShippingApp.Domain.Enums;
using PHShippingApp.Domain.ValueObjects;

namespace PHShippingApp.Domain.Entities
{
    public class ShippingOrder : BaseEntity
    {
        public ShippingOrder(string description, decimal weightInKg, DeliveryAddress deliveryAddress)
        {
            TranckingCode = GenerateTrackingCode();
            Description = description;
            PostedAt = DateTime.Now;
            WeightInKg = weightInKg;
            DeliveryAddress = deliveryAddress;
            Status = ShippingOrderStatus.Started;
            TotalPrice = 0;
            Services = new List<ShippingOrderService>();
        }

        private string GenerateTrackingCode()
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "123456789";

            char[] code = new char[10];
            Random x = new Random();

            for(int i = 0; i < 5; i++)
            {
                code[i] = letters[x.Next(0, letters.Length)];
            }

            for (int i = 5; i < 10; i++)
            {
                code[i] = numbers[x.Next(0, numbers.Length)];
            }

            return new String(code);
        }

        public void SetupServices(List<ShippingService> services)
        {
            foreach(var service in services)
            {
                var servicePrice = service.FixedPrice + service.PricePerKg * WeightInKg;

                TotalPrice += servicePrice;

                Services.Add(new ShippingOrderService(service.Title, servicePrice));
            }
        }

        public void SetCompleted()
        {
            Status = ShippingOrderStatus.Delivered;
        }

        public string TranckingCode { get; set; }

        public string Description { get; set; }

        public DateTime PostedAt { get; set; }

        public decimal WeightInKg { get; set; }

        public DeliveryAddress DeliveryAddress { get; set; }

        public ShippingOrderStatus Status { get; set; }

        public decimal TotalPrice { get; set; }

        public List<ShippingOrderService> Services { get; set; }
    }
}
