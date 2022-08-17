using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DataLayer
{
    public class Page
    {
        [Key]
        public int PageID { get; set; }

        [Display(Name = "گروه صفحه")]
        public int GroupID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250)]
        public string Title { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "متن مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Article { get; set; }

        [Display(Name = "بازدید")]
        public int Visit { get; set; }

        [Display(Name = "تصویر")]
        public string ImagePath { get; set; }

        [Display(Name = "اسلایدر")]
        public bool ShowInSlider { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "کلمات کلیدی")]
        public string Tags { get; set; }


        #region Navigation Property
        public virtual PageGroup PageGroup { get; set; }
        public virtual List<PageComment> PageComments { get; set; }
        public Page() { }
        #endregion
    }
}
