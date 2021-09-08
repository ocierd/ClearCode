using System.Collections.Generic;
using System.Threading.Tasks;
using Clear.CodeSample.Shared.Entities;

namespace Clear.CodeSample.Domain.Operation.Interfaces
{
    
    public interface IOperationMovie
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<IEnumerable<Movie>> GetByCriteriaAsync(string criteria);
    }
}