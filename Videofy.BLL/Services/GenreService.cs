using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Videofy.BLL.Interfaces;
using Videofy.DAL.Data;
using Videofy.DAL.Models;

namespace Videofy.BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<GenreService> _logger;

        public GenreService(ApplicationDbContext context,
            ILogger<GenreService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Get all genres
        /// </summary>
        /// <returns>List of genre</returns>
        #region GetGenres
        public List<Genre> GetGenres() => _context.Genres.ToList();
        #endregion

        /// <summary>
        /// Get genre select list items
        /// </summary>
        /// <returns>list of genre selectlistitem</returns>
        #region GetGenreSelectListItems
        public List<SelectListItem> GetGenreSelectListItems() => _context.Genres
            .Select(g => new SelectListItem
            {
                Text = g.Title,
                Value = g.GenreId.ToString()
            }).ToList();
        #endregion

        /// <summary>
        /// Get genre by id
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns>Genre</returns>
        #region GetGenreById
        public Genre GetGenreById(int genreId) => _context.Genres
            .SingleOrDefault(g => g.GenreId == genreId);
        #endregion

        /// <summary>
        /// add new genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>genre</returns>
        #region AddGenre
        public Genre AddGenere(Genre genre) 
        {
            try
            {
                _context.Genres.Add(genre);
                _context.SaveChanges();

                return genre;
            }
            catch (Exception ex)
            {
                LogError(ex);

                return null;
            }
        }
        #endregion

        /// <summary>
        /// update genre info.
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>genre</returns>
        #region UpdateGenre
        public Genre UpdateGenre(Genre genre) 
        {
            try
            {
                _context.Genres.Update(genre);
                _context.SaveChanges();

                return genre;
            }
            catch (Exception ex)
            {
                LogError(ex);

                return null;
            }
        }
        #endregion

        /// <summary>
        /// remove genre by id.
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns>genre</returns>
        #region RemoveGenre
        public Genre RemoveGenre(int genreId) {
            try
            {
                Genre genre = GetGenreById(genreId);

                _context.Genres.Remove(genre);
                _context.SaveChanges();

                return genre;
            }
            catch (Exception ex)
            {
                LogError(ex);

                return null;
            }
        }
        #endregion

        /// <summary>
        /// Remove genre.
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>genre</returns>
        #region RemoveGenre
        public Genre RemoveGenre(Genre genre) 
        {
            try
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();

                return genre;
            }
            catch (Exception ex)
            {
                LogError(ex);

                return null;
            }
        }
        #endregion

        /// <summary>
        /// search in genres.
        /// </summary>
        /// <param name="genreName"></param>
        /// <returns>list of genres</returns>
        #region SearchGenre
        public List<Genre> SearchGenre(string genreName) 
        {
            if (string.IsNullOrEmpty(genreName))
            {
                return null;
            }

            return _context.Genres
                .Where(g => g.Title.Trim().Contains(genreName.Trim()))
                .ToList();
        }
        #endregion

        /// <summary>
        /// count of genres
        /// </summary>
        /// <returns>genre</returns>
        #region GenreCount
        public byte GenreCount() => (byte)_context.Genres.Count();
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
