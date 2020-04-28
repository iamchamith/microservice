using Abp.Application.Services.Dto;
namespace Amazon.Items.Dto
{
    public class ItemDto : EntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Review { get; set; }
        public int NumberOfAvailableItems { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
    }
}
