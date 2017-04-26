using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Fundamentals.Models;

namespace Fundamentals.Controllers.API
{
    public class CustomersController : BaseController
    {


        // GET: api/Customers
        public IQueryable<CustomerViewModel> GetCustomers()
        {
            return _dbContext.Customers;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(CustomerViewModel))]
        public IHttpActionResult GetCustomerViewModel(int id)
        {
            CustomerViewModel customerViewModel = _dbContext.Customers.Find(id);
            if (customerViewModel == null)
            {
                return NotFound();
            }

            return Ok(customerViewModel);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerViewModel(int id, CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerViewModel.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(customerViewModel).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerViewModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(CustomerViewModel))]
        public IHttpActionResult PostCustomerViewModel(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Customers.Add(customerViewModel);
            _dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerViewModel.Id }, customerViewModel);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(CustomerViewModel))]
        public IHttpActionResult DeleteCustomerViewModel(int id)
        {
            CustomerViewModel customerViewModel = _dbContext.Customers.Find(id);
            if (customerViewModel == null)
            {
                return NotFound();
            }

            _dbContext.Customers.Remove(customerViewModel);
            _dbContext.SaveChanges();

            return Ok(customerViewModel);
        }

       

        private bool CustomerViewModelExists(int id)
        {
            return _dbContext.Customers.Count(e => e.Id == id) > 0;
        }
    }
}