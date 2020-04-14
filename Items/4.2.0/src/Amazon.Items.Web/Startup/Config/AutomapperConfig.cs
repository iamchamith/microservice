using Abp.AutoMapper;
using Amazon.Items.Dto;
using Amazon.Items.Entities;
using Amazon.Items.Web.ViewModel;

namespace Amazon.Items.Web.Startup.Config
{
    public static class AutomapperConfig
    {
        public static void RegisterAutomapper(this IAbpAutoMapperConfiguration automapper)
        {
            automapper.Configurators.Add(config =>
            {
                config.CreateMap<Brand, BrandDto>().ReverseMap();
                config.CreateMap<BrandDto, BrandViewModel>().ReverseMap();

                config.CreateMap<Item, ItemDto>().ReverseMap();
                config.CreateMap<ItemDto, ItemViewModel>().ReverseMap();
            });
        }

    }
}
