using System;

namespace Amazon.Items.Dto
{
    [Serializable]
    public class ItemSearchByRequest
    {
        public string Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? Brand { get; set; }
    }
}
