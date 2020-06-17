using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Videofy.DAL.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "لطفاً {0} را وارد نمایید.")]
        [MaxLength(150)]
        public string Title { get; set; }

        public DateTime LatestUpdate { get; set; }

        #region Relations
        public ICollection<MovieGenre> Movies { get; set; }
        #endregion
    }
}
