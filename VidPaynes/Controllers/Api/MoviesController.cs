using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidPaynes.DTOs;
using VidPaynes.Models;

namespace VidPaynes.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/Movies get list of all movies
        public IEnumerable<MoviesDTO> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.Stock > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MoviesDTO>);
        }

        // Get api/Movies/1
        public MoviesDTO GetMovie(int id)
        {
            var movieDto = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieDto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Movie, MoviesDTO>(movieDto);
        }

        // Post api/movies/create
        [HttpPost]
        public IHttpActionResult AddMovie(MoviesDTO movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MoviesDTO, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);

        }

        // PUT api/Movies/edit/1
        [HttpPut]
        public IHttpActionResult EditMovie(int id, MoviesDTO moviesDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(moviesDTO, movieInDb);

            return Created(new Uri(Request.RequestUri + "/" + movieInDb.Id), movieInDb);
        }

        // DELETE api/Movies/remove/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);

            _context.SaveChanges();

            return Ok();
        }
    }
}
