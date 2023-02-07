using PHShippingApp.Application.ViewModels;

namespace PHShippingApp.Application.Services.Interfaces
{
    public interface IShippingServiceService
    {
        Task<List<ShippingServiceViewModel>> GetAll();
    }
}
