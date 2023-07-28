using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using MoviesAPI.Repositories;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly IMovieService _service;

        public MoviesController (IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies ()
        {
            try
            {
                var listMovies = await _service.GetAllMovies();
                return Ok(listMovies);

            }
            catch (Exception ex) {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            return Ok(await _service.GetMovieById(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertMovie([FromBody] MovieViewModel movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.InsertMovie(movie);

            return Created("Pelicula creada", response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromBody] MovieViewModel movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.UpdateMovie(movie);

            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _service.DeleteMovie(id);
            return NoContent();
        }
    }
}
