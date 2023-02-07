using PHShippingApp.Application.InputModels;
using PHShippingApp.Application.ViewModels;

namespace PHShippingApp.Application.Services.Interfaces
{
    public interface IShippingOrderService
    {
        Task<string> Add(AddShippingOrderInputModel addShippingOrderInputModel);

        Task<ShippingOrderViewModel> GetByCode(string trackingCode);
    }
}
