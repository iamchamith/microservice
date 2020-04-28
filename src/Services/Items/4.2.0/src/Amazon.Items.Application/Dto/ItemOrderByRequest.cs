using System;

namespace Amazon.Items.Dto
{
    [Serializable]
    public class ItemOrderByRequest
    {
        public bool Name { get; set; }
        public bool Price { get; set; }
        public bool Review { get; set; }
    }
}
