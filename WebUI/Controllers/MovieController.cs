using System.Collections.Generic;
using System.Threading.Tasks;
using Clear.CodeSample.Domain.Operation;
using Clear.CodeSample.Domain.Operation.Interfaces;
using Clear.CodeSample.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Clear.CodeSample.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : BaseController
    {

        private readonly ILogger<MovieController> _logger;
        
        private readonly IOperationMovie OperationMovie;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
            OperationMovie = new OperationMovie();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            Movie movie = await OperationMovie.GetMovieByIdAsync(id);
            return movie;
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> Get()
        {
            IEnumerable<Movie> movies = await OperationMovie.GetMoviesAsync();
            return movies;
        }


        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetByCriteria(string criteria)
        {
            IEnumerable<Movie> movies = await OperationMovie.GetByCriteriaAsync(criteria);
            return Ok(movies);
        }




    }
}
