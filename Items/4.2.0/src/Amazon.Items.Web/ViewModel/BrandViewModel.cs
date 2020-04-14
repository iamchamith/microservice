using App.SharedKernel.Model;
using App.SharedKernel.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Amazon.Items.Web.ViewModel
{
    public class BrandViewModel : BaseViewModel
    {
        [Required, StringLength(DataAnnotationsConst.NAME_LENGTH)]
        public string Name { get; set; }
        [Required, StringLength(DataAnnotationsConst.DESCRIPTION_LENGTH)]
        public string Description { get; set; }
        [Required, StringLength(DataAnnotationsConst.IMAGE_LENGTH)]
        public string Image { get; set; }
    }
}
