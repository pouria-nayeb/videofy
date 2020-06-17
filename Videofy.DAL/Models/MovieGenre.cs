using System.ComponentModel.DataAnnotations;

namespace Videofy.DAL.Models
{
    public class MovieGenre
    {
        [Key]
        public int MovieGenreId { get; set; }

        public int MovieId { get; set; }

        public int GenreId { get; set; }

        #region Relations
        public Movie Movie { get; set; }

        public Genre Genre { get; set; }
        #endregion
    }
}
