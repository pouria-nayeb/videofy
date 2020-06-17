using System.Collections.Generic;

namespace Videofy.BLL.ViewModels.Movies
{
    public class MoviePagingViewModel
    {
        public List<MovieViewModel> Movies { get; set; }

        public int PageNumber { get; set; }

        public int PagesCount { get; set; }
    }
}
