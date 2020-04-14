using Abp.Domain.Entities;
using App.SharedKernel.Utilities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazon.Items.Entities
{
    [Table(nameof(Brand), Schema = ItemsConsts.SCHEMA)]
    public class Brand : Entity, ISoftDelete
    {
        [Required, StringLength(DataAnnotationsConst.NAME_LENGTH)]
        public virtual string Name { get; private set; }
        [Required, StringLength(DataAnnotationsConst.DESCRIPTION_LENGTH)]
        public virtual string Description { get; private set; }
        [Required, StringLength(DataAnnotationsConst.IMAGE_LENGTH)]
        public virtual string Image { get; private set; }

        public virtual ICollection<Item> Items { get; set; }
        public bool IsDeleted { get; set; }
    }
}
