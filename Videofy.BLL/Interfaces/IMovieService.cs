using System;
using System.Collections.Generic;
using Videofy.BLL.ViewModels.Movies;
using Videofy.DAL.Models;

namespace Videofy.BLL.Interfaces
{
    public interface IMovieService : IDisposable
    {
        /// <summary>
        /// Get paginated list of movies.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>paginated list of movies</returns>
        #region GetMovies
        MoviePagingViewModel GetAllMovies(int pageNumber = 1, int pageSize = 32);
        #endregion

        /// <summary>
        /// Get movie by id.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>movie</returns>
        #region GetMovieById
        Movie GetMovieById(int movieId);
        #endregion

        /// <summary>
        /// Add movie data.
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="genreIds"></param>
        /// <returns>movie</returns>
        #region AddMovie
        Movie AddMovie(Movie movie, List<int> genreIds);
        #endregion

        /// <summary>
        /// update movie data.
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="genreIds"></param>
        /// <returns>movie</returns>
        #region UpdateMovie
        Movie UpdateMovie(Movie movie, List<int> genreIds);
        #endregion

        /// <summary>
        /// remove movie by id.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>movie</returns>
        #region RemoveMovie
        Movie RemoveMovie(int movieId);
        #endregion

        /// <summary>
        /// Remove movie.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>movie</returns>
        #region RemoveMovie
        Movie RemoveMovie(Movie movie);
        #endregion

        /// <summary>
        /// Search in movies.
        /// </summary>
        /// <param name="movieTitle"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>paginated list of movies</returns>
        #region SearchMovies
        MoviePagingViewModel SearchMovies(string movieTitle, int pageNumber = 1, int pageSize = 32);
        #endregion

        /// <summary>
        /// Movies count.
        /// </summary>
        /// <returns>number of movies</returns>
        #region MoviesCount
        int MoviesCount();
        #endregion
    }
}
