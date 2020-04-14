using Abp.Application.Services.Dto;

namespace Amazon.Items.Dto
{
    public class BrandDto : EntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
