using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Videofy.DAL.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        [MaxLength(320, ErrorMessage = "{0} نمی تواند از {1} کاراکتر بیشتر باشد.")]
        public string Title { get; set; }

        [Display(Name = "رده سنی")]
        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        [MaxLength(12, ErrorMessage = "{0} نمی تواند از {1} کاراکتر بیشتر باشد.")]
        public string Rate { get; set; }

        [Display(Name = "تاریخ عرضه")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        [MinLength(25, ErrorMessage = "{0} نمی تواند از {1} کاراکتر کمتر باشد.")]
        public string Description { get; set; }

        [Display(Name = "آخرین بروزرسانی")]
        [DataType(DataType.Date)]
        public DateTime LatestUpdate { get; set; }

        #region Relations
        public ICollection<MovieGenre> Genres { get; set; }
        #endregion
    }
}
