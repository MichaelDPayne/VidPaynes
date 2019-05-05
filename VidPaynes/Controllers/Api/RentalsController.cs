using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidPaynes.DTOs;
using VidPaynes.Models;

namespace VidPaynes.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rental)
        {

            if (rental.MovieIds.Count == 0)
                return BadRequest("No Movie ID's have been provided");

            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _context.Customers.SingleOrDefault(c => c.Id == rental.CustomerId);

            if (customer == null)
                return BadRequest("Invalid Customer");

            var movies = _context.Movies.Where(m => rental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != rental.MovieIds.Count)
                return BadRequest("One or more Movies has not loaded");

            foreach (var movie in movies)
            {

                if (movie.Stock == 0)
                    return BadRequest(movie.Name + "is Out of Stock");

                if (customer.MoviesRented != null)
                {
                    if (customer.MoviesRented.Count == 3)
                        return BadRequest("Customers can Only Rent 3 Movies at a Time");

                    customer.MoviesRented.Add(movie);
                }

                movie.Stock--;

                var newRental = _context.Rentals.Add(new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                });
            }

            _context.SaveChanges();

            return Ok();

        }

    }
}
