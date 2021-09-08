using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clear.CodeSample.Shared.Entities;

namespace Clear.CodeSample.Persistence.Repository.Interfaces
{
    public interface IMovieRepository : IDisposable
    {

        Task<IEnumerable<Movie>> GetMovies();

        Task<Movie> GetMovieById(int id);


        Task<IEnumerable<Movie>> SearchByCriteria(string criteria);

    }
}