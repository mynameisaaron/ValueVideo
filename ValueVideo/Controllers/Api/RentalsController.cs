using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using ValueVideo.Dtos;
using ValueVideo.Models;

namespace ValueVideo.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //[HttpPost]
        //public IHttpActionResult NewRental(RentalDto rentalDto)
        //{
        //    var rental = new Rental();
        //    rental.Customer = _context.Customers.Single(s => s.Id == rentalDto.CustomerId);
        //    rental.CustomerId = rentalDto.CustomerId;
        //    rental.CheckOutDate = DateTime.Now;
        //    rental.Movie = _context.Movies.Single(m => m.Id == rentalDto.MovieId);
        //    rental.MovieId = rentalDto.MovieId;
            

        //    var movie = _context.Movies.Single(m => m.Id == rental.MovieId);
        //    movie.NumberAvailable = (byte)(movie.NumberAvailable - 1);
            

        //    _context.Rentals.Add(rental);
        //    _context.SaveChanges();

        //    return Ok();
        //}

        [HttpGet]
        public IHttpActionResult GetAllUnreturned()
        {
            var unreturnedRentalDtos = _context.Rentals.Where(r => r.Returned == false)
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);

            return Ok(unreturnedRentalDtos);
        }

        //[HttpGet]
        //public IHttpActionResult GetByCustomerId(int id)
        //{
        //    var rentals =
        //        _context.Rentals.Where(r => r.CustomerId == id)
        //            .Include(R => R.Movie)
        //            .ToList()
        //            .Select(Mapper.Map<Rental, RentalDto>);
        //    return Ok(rentals);
        //}
        [HttpGet]
        public IHttpActionResult GetAll(int id)
        {
            if (id != 1)
                return BadRequest();


            
                var all =
                    _context.Rentals.Include(r => r.Customer)
                        .Include(r => r.Movie).Where(r=>r.Returned == true)
                        .ToList()
                        .Select(Mapper.Map<Rental, RentalDto>);

            return Ok(all);
        }

        [HttpDelete]
        public IHttpActionResult CustomerReturnAll(int id)
        {
            var toReturn = _context.Rentals.Where(a => a.Returned == false && a.CustomerId == id).ToList();
            foreach (var rental in toReturn)
            {
                rental.Returned = true;
                rental.ReturnDate = DateTime.Now;
                var movie = _context.Movies.Single(m => m.Id == rental.MovieId);
                movie.NumberAvailable = (byte)(movie.NumberAvailable + 1);
            }
            _context.SaveChanges();
            return Ok();

        }

        //This is specific to the Index view sending a a NewRentals Dto from the form
        [HttpPost]
        public IHttpActionResult NewRentals(NewRentalsDto newRentalsDto)
        {
            var id = newRentalsDto.CustomerId;
            var sequenceOfMovieIds = newRentalsDto.MovieIds;

            foreach (var item in sequenceOfMovieIds)
            {
                var rental =new Rental()
                {
                    CustomerId = id,
                    MovieId = item,
                    CheckOutDate = DateTime.Now
                };

                   var movie = _context.Movies.Single(m => m.Id == item);
                   movie.NumberAvailable = (byte)(movie.NumberAvailable - 1);

                _context.Rentals.Add(rental);
                _context.SaveChanges();

            }

            
            return Ok();

        }

        [HttpPut]
        public IHttpActionResult ReturnSingle(int id)
        {
            var rentalid = id;
            var rentalInDatabase =_context.Rentals.Single(r => r.Id == rentalid);
            rentalInDatabase.Returned = true;
            rentalInDatabase.ReturnDate = DateTime.Now;

            _context.SaveChanges();
            return Ok(id);

        }


    }
}
