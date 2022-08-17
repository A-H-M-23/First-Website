using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class PageGroup
    {
        [Key]
        public int GroupID { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string GroupTitle { get; set; }


        #region Navigation Property
        public virtual List<Page> Pages { get; set; }
        public PageGroup() { }
        #endregion
    }
}
