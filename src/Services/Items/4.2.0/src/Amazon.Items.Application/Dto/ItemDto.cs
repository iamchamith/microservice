using Abp.Application.Services.Dto;
using Amazon.Items.Entities;
using App.SharedKernel;

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

        public ItemDto SetImageWithPath()
        {
            Image = $"{GlobalConfig.Host}/{nameof(Item)}s/{Image}";
            return this;
        }
    }
}
