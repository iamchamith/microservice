using Abp.AutoMapper;
using Amazon.Order.Dto;
using Amazon.Order.Web.Model;
using entity = Amazon.Order.Entities;
namespace Amazon.Order.Web.Startup.Config
{
    public static class AutomapperConfig
    {
        public static void RegisterAutomapper(this IAbpAutoMapperConfiguration automapper)
        {
            automapper.Configurators.Add(config =>
            {
                config.CreateMap<OrderDto, entity.Order>().ReverseMap();
                config.CreateMap<OrderDto, OrderViewModel>().ReverseMap();

                config.CreateMap<OrderItemDto, entity.OrderItem>().ReverseMap();
                config.CreateMap<OrderItemDto, OrderViewModel>().ReverseMap();

                config.CreateMap<PaymentDto, entity.Payment>().ReverseMap();
                config.CreateMap<PaymentDto, PaymentViewModel>().ReverseMap();

                config.CreateMap<ShippingDto, entity.Shipping>().ReverseMap();
                config.CreateMap<ShippingDto, ShippingViewModel>().ReverseMap();
            });
        }

    }
}
