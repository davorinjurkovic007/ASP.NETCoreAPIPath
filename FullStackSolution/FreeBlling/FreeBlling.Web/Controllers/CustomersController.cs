using FreeBilling.Data.Entities;
using FreeBlling.Web.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FreeBlling.Web.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize(AuthenticationSchemes = IdentityConstants.BearerScheme)]
    [Authorize("api")]
    //[Route("/api/customers")]
    [Route("/api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IBillingRepository _billingRepository;

        public CustomersController(ILogger<CustomersController> logger, IBillingRepository billingRepository)
        {
            _logger = logger;
            _billingRepository = billingRepository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Customer>>> Get(bool withAddresses = false) 
        {
            try
            {
                IEnumerable<Customer> results;

                if(withAddresses)
                {
                    results = await _billingRepository.GetCustomersWithAddresses();
                }
                else
                {
                    results = await _billingRepository.GetCustomers();
                }

                return Ok(results);
            }
            catch (Exception) 
            {
                _logger.LogError("Failed to get customers from database.");
                return Problem("Failed to get customers from database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> GetOne(int id)
        {
            try
            {
                var result = await _billingRepository.GetCustomer(id);

                if (result is null)
                {
                    return NotFound();
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception thrown while reading customer");
                return Problem($"Exception thrown: {ex.Message}");
            }
        }
    }
}
