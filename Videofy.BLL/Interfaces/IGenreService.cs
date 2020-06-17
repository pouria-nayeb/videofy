using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Videofy.DAL.Models;

namespace Videofy.BLL.Interfaces
{
    public interface IGenreService : IDisposable
    {
        /// <summary>
        /// Get all genres
        /// </summary>
        /// <returns>List of genre</returns>
        #region GetGenres
        List<Genre> GetGenres();
        #endregion

        /// <summary>
        /// Get genre select list items
        /// </summary>
        /// <returns>list of genre selectlistitem</returns>
        #region GetGenreSelectListItems
        List<SelectListItem> GetGenreSelectListItems();
        #endregion

        /// <summary>
        /// Get genre by id
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns>Genre</returns>
        #region GetGenreById
        Genre GetGenreById(int genreId);
        #endregion

        /// <summary>
        /// add new genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>genre</returns>
        #region AddGenre
        Genre AddGenere(Genre genre);
        #endregion

        /// <summary>
        /// update genre info.
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>genre</returns>
        #region UpdateGenre
        Genre UpdateGenre(Genre genre);
        #endregion

        /// <summary>
        /// remove genre by id.
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns>genre</returns>
        #region RemoveGenre
        Genre RemoveGenre(int genreId);
        #endregion

        /// <summary>
        /// Remove genre.
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>genre</returns>
        #region RemoveGenre
        Genre RemoveGenre(Genre genre);
        #endregion

        /// <summary>
        /// search in genres.
        /// </summary>
        /// <param name="genreName"></param>
        /// <returns>list of genres</returns>
        #region SearchGenre
        List<Genre> SearchGenre(string genreName);
        #endregion

        /// <summary>
        /// count of genres
        /// </summary>
        /// <returns>genre</returns>
        #region GenreCount
        byte GenreCount();
        #endregion
    }
}
