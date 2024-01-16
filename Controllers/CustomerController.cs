
using microservices_customerapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace microservices_customerapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{

    private readonly CustomerDbContext _customerDbContext;

    public CustomerController(CustomerDbContext customerDbContext)
    {
        _customerDbContext = customerDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
        return await _customerDbContext.Customers.ToListAsync();
    }

    [HttpGet("CustomerId:int")]
    public async Task<ActionResult<Customer>> GetById(int customerId)
    {
        return await _customerDbContext.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCustomer(Customer customer)
    {
        if (customer is null) return BadRequest();

        await _customerDbContext.Customers.AddAsync(customer);
        await _customerDbContext.SaveChangesAsync();

        return Ok();
    }


    [HttpPut("CustomerId:int")]
    public async Task<ActionResult> UpdateCustomer(int CustomerId, Customer customer)
    {
        var customerEntity = await _customerDbContext.Customers.FirstAsync(x => x.Id == CustomerId);
        if (customerEntity is null) return NoContent();

        customerEntity.ContactNo = customer.ContactNo;
        customerEntity.FName = customer.FName;
        customerEntity.LName = customer.LName;
        customerEntity.Gender = customer.Gender;
        customerEntity.Address = customer.Address;
        customerEntity.EmailId = customer.EmailId;

        _customerDbContext.Customers.Update(customer);

        await _customerDbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("CustomerId:int")]
    public async Task<ActionResult> DeleteCustomer(int CustomerId)
    {
        var customerEntity = await _customerDbContext.Customers.FirstAsync(x => x.Id == CustomerId);
        if (customerEntity is null) return NoContent();

        _customerDbContext.Customers.Remove(customerEntity);

        await _customerDbContext.SaveChangesAsync();

        return Ok();
    }
}