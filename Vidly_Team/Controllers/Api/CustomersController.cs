using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Vidly_Team.Dtos;
using Vidly_Team.Models;

namespace Vidly_Team.Controllers.Api
{
    [EnableCorsAttribute("*", "*", "*")]
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
      
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Get /api/customers
        [ResponseType(typeof(CustomerDto))]
        public IHttpActionResult GetCustomers()
        {
            try
            {
                var customers =
                    _context.Customers.Select(Mapper.Map<Customer, CustomerDto>);

                return Ok( customers);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ResponseType(typeof(CustomerDto))]
        // Get /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        { 
           
            try
            {
                   
                Customer customer;
                if (id > 0)
                {
                    customer = _context.Customers.SingleOrDefault(c => c.Id == id);
                    if (customer == null)
                    {

                        return NotFound();
                    }
                }
                else
                {
                    customer = new Customer
                    {

                        IsSubscribeToNewsletter = true,

                    };
                }
                return Ok(Mapper.Map<Customer, CustomerDto>(customer));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Post /api/customers
        [ResponseType(typeof(CustomerDto))]
        [HttpPost]
        public IHttpActionResult CreateCustomer([FromBody]CustomerDto customerDto)
        {
            try
            {
                if (customerDto == null)
                {
                    return BadRequest("Customer cannot be null");
                }
                if (!ModelState.IsValid)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

                _context.Customers.Add(customer);
                _context.SaveChanges();
                customerDto.Id = customer.Id;
                return Created<CustomerDto>(Request.RequestUri+customerDto.Id.ToString(),customerDto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            

        }
        // PUT /api/customers/1
        [ResponseType(typeof(CustomerDto))]
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,[FromBody] CustomerDto customerDto)
        {
            try
            {
                if (customerDto == null)
                {
                    return BadRequest("Customer cannot be null");

                }

                if (!ModelState.IsValid)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                var customerIndb = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customerIndb == null)
                {
                    return NotFound();
                }

                Mapper.Map(customerDto, customerIndb);

                _context.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
           
        }
        // Delete /api/customers/1
        [ResponseType(typeof(CustomerDto))]
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            try
            {
                
                var customerIndb = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customerIndb == null)
                {
                    return BadRequest("Wrong customer id");
                }
                _context.Customers.Remove(customerIndb);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
           
        }
    }
}
