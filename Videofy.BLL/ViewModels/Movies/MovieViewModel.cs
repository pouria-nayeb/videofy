using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Videofy.BLL.ViewModels.Movies
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public List<int> Genres { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }
    }
}
