using App.SharedKernel.Model;
using App.SharedKernel.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Amazon.Items.Web.ViewModel
{
    public class ItemViewModel:BaseViewModel
    {
        [Required, StringLength(DataAnnotationsConst.NAME_LENGTH)]
        public virtual string Name { get; private set; }
        [Required, StringLength(DataAnnotationsConst.DESCRIPTION_LENGTH)]
        public virtual string Description { get; private set; }
        [Required, StringLength(DataAnnotationsConst.IMAGE_LENGTH)]
        public virtual string Image { get; private set; }
        [Range(0, 5)]
        public virtual int Review { get; private set; }
        public virtual int NumberOfAvailableItems { get; private set; }
        public virtual decimal Price { get; private set; }
        public virtual int BrandId { get; private set; }
    }
}
