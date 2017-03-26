using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using ValueVideo.Dtos;
using ValueVideo.Models;

namespace ValueVideo.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public IHttpActionResult GetMovies(string query = null)
        {

            var moviesQuery = _context.Movies.Include(m => m.Genre);

            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query) && m.NumberAvailable > 0);
            }

            List<Movie> _movies = moviesQuery.ToList();
            var movieDtos = _movies.Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDtos);

            

        }

        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var Movie = _context.Movies.Include(m=>m.Genre).SingleOrDefault(m=>m.Id == id);
            return Ok(Movie);

        }

        [HttpDelete]
        public IHttpActionResult RemoveMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie == null)
                return BadRequest("This movie is not in the database");

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }
    }
}
