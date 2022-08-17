using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class PageComment
    {
        [Key]
        public int CommentID { get; set; }

        [Display(Name = "خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PageID { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Email { get; set; }

        [Display(Name = "سایت")]
        [MaxLength(200)]
        public string WebSite { get; set; }

        [Display(Name = "دیدگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }


        #region Navigation Property
        public virtual Page Page { get; set; }
        public PageComment() { }
        #endregion
    }
}
