using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Videofy.BLL.Interfaces;
using Videofy.BLL.ViewModels.Movies;
using Videofy.DAL.Data;
using Videofy.DAL.Models;

namespace Videofy.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MovieService> _logger;

        public MovieService(ApplicationDbContext context,
            ILogger<MovieService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Get paginated list of movies.
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>paginated list of movies</returns>
        #region GetMovies
        public MoviePagingViewModel GetAllMovies(int pageNumber = 1, int pageSize = 32)
        {
            IQueryable<Movie> movies = _context.Movies;

            int take = pageSize;
            int skip = (pageNumber - 1) * take;

            int moviesCount = movies.Count();

            int pagesCount = (int)Math.Ceiling(decimal.Divide(moviesCount, take));

            return new MoviePagingViewModel
            {
                Movies = movies
                .Skip(skip)
                .Take(take)
                .OrderByDescending(m => m.MovieId)
                                .Select(m => new MovieViewModel
                                {
                                    MovieId = m.MovieId,
                                    Title = m.Title,
                                    Genres = m.Genres.Select(g => g.GenreId).ToList(),
                                    ReleaseDate = m.ReleaseDate,
                                    Description = m.Description
                                })
                .ToList(),
                PageNumber = pageNumber,
                PagesCount = pagesCount
            };
        }
        #endregion

        /// <summary>
        /// Get movie by id.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>movie</returns>
        #region GetMovieById
        public Movie GetMovieById(int movieId) => _context.Movies
            .SingleOrDefault(m => m.MovieId == movieId);
        #endregion

        /// <summary>
        /// Add movie data.
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="genreIds"></param>
        /// <returns>movie</returns>
        #region AddMovie
        public Movie AddMovie(Movie movie, List<int> genreIds) 
        {
            try
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                #region Add genres to movie
                foreach (var genreId in genreIds)
                {
                    _context.MovieGenres.Add(new MovieGenre
                    {
                        MovieId = movie.MovieId,
                        GenreId = genreId
                    });

                    _context.SaveChanges();
                }
                #endregion

                return movie;
            }
            catch (Exception ex)
            {
                LogError(ex);

                return null;
            }
        }
        #endregion

        /// <summary>
        /// update movie data.
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="genreIds"></param>
        /// <returns>movie</returns>
        #region UpdateMovie
        public Movie UpdateMovie(Movie movie, List<int> genreIds) 
        {
            try
            {
                #region Remove old genres from movie if exist
                if (_context.MovieGenres
                    .Any(mg => mg.MovieId == movie.MovieId))
                {
                    _context.MovieGenres
                    .Where(mg => mg.MovieId == movie.MovieId)
                    .ToList()
                    .ForEach(mg => _context.MovieGenres.Remove(mg));
                }
                #endregion

                _context.Movies.Update(movie);
                _context.SaveChanges();

                #region Add genres to movie
                foreach (var genreId in genreIds)
                {
                    _context.MovieGenres.Add(new MovieGenre
                    {
                        MovieId = movie.MovieId,
                        GenreId = genreId
                    });

                    _context.SaveChanges();
                }
                #endregion

                return movie;
            }
            catch (Exception ex)
            {
                LogError(ex);

                return null;
            }
        }
        #endregion

        /// <summary>
        /// remove movie by id.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>movie</returns>
        #region RemoveMovie
        public Movie RemoveMovie(int movieId) 
        {
            try
            {
                Movie movie = GetMovieById(movieId);

                #region Remove old genres from movie if exist
                if (_context.MovieGenres
                    .Any(mg => mg.MovieId == movie.MovieId))
                {
                    _context.MovieGenres
                    .Where(mg => mg.MovieId == movie.MovieId)
                    .ToList()
                    .ForEach(mg => _context.MovieGenres.Remove(mg));
                }
                #endregion

                _context.Movies.Remove(movie);
                _context.SaveChanges();

                return movie;
            }
            catch (Exception ex)
            {
                LogError(ex);

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Remove movie.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>movie</returns>
        #region RemoveMovie
        public Movie RemoveMovie(Movie movie)
        {
            try
            {
                #region Remove old genres from movie if exist
                if (_context.MovieGenres
                    .Any(mg => mg.MovieId == movie.MovieId))
                {
                    _context.MovieGenres
                    .Where(mg => mg.MovieId == movie.MovieId)
                    .ToList()
                    .ForEach(mg => _context.MovieGenres.Remove(mg));
                }
                #endregion

                _context.Movies.Remove(movie);
                _context.SaveChanges();

                return movie;
            }
            catch (Exception ex)
            {
                LogError(ex);

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Search in movies.
        /// </summary>
        /// <param name="movieTitle"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>paginated list of movies</returns>
        #region SearchMovies
        public MoviePagingViewModel SearchMovies(string movieTitle, int pageNumber = 1, int pageSize = 32)
        {
            IQueryable<Movie> movies = _context.Movies
                .Where(m => m.Title.Trim().Contains(movieTitle.Trim()));

            int take = pageSize;
            int skip = (pageNumber - 1) * take;

            int moviesCount = movies.Count();

            int pagesCount = (int)Math.Ceiling(decimal.Divide(moviesCount, take));

            return new MoviePagingViewModel
            {
                Movies = movies
                .Skip(skip)
                .Take(take)
                .OrderByDescending(m => m.MovieId)
                                .Select(m => new MovieViewModel
                                {
                                    MovieId = m.MovieId,
                                    Title = m.Title,
                                    Genres = m.Genres.Select(g => g.GenreId).ToList(),
                                    ReleaseDate = m.ReleaseDate,
                                    Description = m.Description
                                })
                .ToList(),
                PageNumber = pageNumber,
                PagesCount = pagesCount
            };
        }
        #endregion

        /// <summary>
        /// Movies count.
        /// </summary>
        /// <returns>number of movies</returns>
        #region MoviesCount
        public int MoviesCount() => _context.Movies.Count();
        #endregion

        #region Helpers
        /// <summary>
        /// Log errors.
        /// </summary>
        /// <param name="ex"></param>
        private void LogError(Exception ex)
        {
            _logger.LogError($"StackTrace: {ex.StackTrace}\nErrorMessage: {ex.Message}");
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                GC.SuppressFinalize(this);
            }
        }
        #endregion
    }
}
