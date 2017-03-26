using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using ValueVideo.Dtos;
using ValueVideo.Models;

namespace ValueVideo.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpGet]
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers.Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customers = customersQuery.ToList().Select(Mapper.Map<Customer,CustomerDto>);
            return Ok(customers);
        }

        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).Single(c=>c.Id == id);
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));

        }

        [HttpDelete]
        public IHttpActionResult RemoveCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
                return BadRequest("Customer is not in the database");

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Ok();

        }
    }
}
