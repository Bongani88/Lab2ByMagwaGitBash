using Microsoft.AspNetCore.Mvc;
using Lab2.CommonModules.Interface;
using Lab2.CommonModules.Entity;
using System.Threading.Tasks;
using Lab2.Infrastructure.Repoistory;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        CustomerRepo customerRepo = new CustomerRepo();

        private readonly ICustomer _customerService;

        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            try
            {
               
                var result = await _customerService.Add(customer);
                if (result == true)
                {
                    return Ok("Customer added successfully");
                }
                else
                {
                    return BadRequest("Customer not added");
                }

            } catch (Exception ex)
            {
                Console.WriteLine($"Error deleting customer: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

       

        [HttpGet]
        [Route("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            try
            {
                var result  = await _customerService.Get(new Customer());
                if (result != null) 
                {
                    return Ok(result);
                } else
                {
                    return NotFound(result);
                }
            } catch (Exception ex) 
            {
                Console.WriteLine($"Error getting customer: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            try
            {
                // Remove redundant call to customerRepo.Update
                var result = await _customerService.Update(customer);
                if (result)
                {
                    return Ok("Customer updated successfully");
                }
                else
                {
                    return BadRequest("Failed to update customer");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine($"Error updating customer: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int customerID)
        {
            try
            {
                var result = await _customerService.Delete(customerID);

                if (result == true)
                {
                    return Ok("Customer deleted succeessfully");
                }
                else
                {
                    return NotFound("Customer not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting customer: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
