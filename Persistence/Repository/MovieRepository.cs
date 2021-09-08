using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clear.CodeSample.Persistence.Repository.Interfaces;
using Clear.CodeSample.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Clear.CodeSample.Persistence.Repository
{
    public class MovieRepository : IMovieRepository, IDisposable
    {
        private readonly ClearContext ClearContext;

        public MovieRepository()
        {
            ClearContext = new ClearContext();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            Movie movie = await ClearContext.Movie.FindAsync(id);
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            
            IEnumerable<Movie> movies = await ClearContext.Movie.Include(m => m.Category).Include(b => b.Director).ToListAsync();
            return movies;
        }


        public async Task<IEnumerable<Movie>> SearchByCriteria(string criteria)
        {
            IEnumerable<Movie> matched = await ClearContext.Movie.FromSqlRaw("EXEC Movie_SearchByCriteria {0}", criteria).ToListAsync();
            return matched;
        }




        #region Explicit dispose implementation

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~MovieRepository()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


        #endregion

    }
}