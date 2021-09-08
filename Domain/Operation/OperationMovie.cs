
using System.Collections.Generic;
using System.Threading.Tasks;
using Clear.CodeSample.Domain.Operation.Interfaces;
using Clear.CodeSample.Persistence;
using Clear.CodeSample.Persistence.Repository;
using Clear.CodeSample.Persistence.Repository.Interfaces;
using Clear.CodeSample.Shared.Entities;

namespace Clear.CodeSample.Domain.Operation
{
    public class OperationMovie : IOperationMovie
    {
        private IMovieRepository MovieRepository;


        public OperationMovie()
        {
            MovieRepository = new MovieRepository();
        }

        public OperationMovie(IMovieRepository movieRepository)
        {
            MovieRepository = movieRepository;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            Movie movie = await MovieRepository.GetMovieById(id);
            return movie;
        }
        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            IEnumerable<Movie> movies = await MovieRepository.GetMovies();
            return movies;
        }

        public async Task<IEnumerable<Movie>> GetByCriteriaAsync(string criteria)
        {

            IEnumerable<Movie> matchedMovies = await MovieRepository.SearchByCriteria(criteria);
            return matchedMovies;
        }
    }
}
