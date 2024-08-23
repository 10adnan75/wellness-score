using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wellness_Score_API.DataContext;
using Wellness_Score_API.Interfaces;
using Wellness_Score_API.Models;

namespace Wellness_Score_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDiagnosisRepository _diagnosisRepository;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository customerRepository, IMapper mapper, IDiagnosisRepository diagnosisRepository)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _diagnosisRepository = diagnosisRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = _mapper.Map<List<CustomerDto>>(_customerRepository.GetCustomers());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customers);
        }

        [HttpGet("CustomerById/{CustomerId}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        public async Task<IActionResult> GetCustomer(int CustomerId)
        {
            var customer = _customerRepository.GetCustomerById(CustomerId);
            if(customer == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customer);
        }

        [HttpGet("CustomerByName/{Name}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        public async Task<IActionResult> GetCustomerByName(string Name)
        {
            var customer = _customerRepository.GetCustomerByName(Name);
            if (customer == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customer);
        }

        [HttpGet("CustomerByEmail/{Email}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        public async Task<IActionResult> GetCustomerByEmail(string Email)
        {
            var customer = _customerRepository.GetCustomerByEmail(Email);
            if(customer == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer CreateCustomer)
        {
            if (CreateCustomer == null) return BadRequest(ModelState);
            var c = _customerRepository.GetCustomers().Where(c => c.Name.Trim().ToUpper() == CreateCustomer.Name.Trim().ToUpper() && c.Email.Trim() == CreateCustomer.Email.Trim()).FirstOrDefault();
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (c != null)
            {
                ModelState.AddModelError("", "User Already Exists");
                return StatusCode(422, ModelState);
            }
            CreateCustomer.Diagnosis.WellnessScore = _customerRepository.GetWellnessScore(CreateCustomer);
            if (!_customerRepository.CreateCustomer(CreateCustomer))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500,ModelState);
            }
            return Ok("Customer Added Successfully");
        }

        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] CustomerDto UpdateCustomer)
        {
            Customer customer = new Customer();

            if(UpdateCustomer== null) return BadRequest(ModelState);

            if (!_customerRepository.CustomerExists(UpdateCustomer.CustomerId))
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerMap = _mapper.Map<Customer>(UpdateCustomer);
            //customer = _customerRepository.GetCustomerById(UpdateCustomer.CustomerId);
            //customerMap.Diagnosis = _diagnosisRepository.GetDiagnosis(customer.Diagnosis.Id);

            if (!_customerRepository.UpdateCustomer(customerMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating customer");
                return StatusCode(500, ModelState);
            }
            return Ok("Customer Updated Successfully");
        }

        [HttpDelete("{CustomerId}")]
        public IActionResult DeleteCustomer(int CustomerId)
        {
            if (!_customerRepository.CustomerExists(CustomerId))
                return NotFound();
            var customer = _customerRepository.GetCustomerById(CustomerId);
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if(!_customerRepository.DeleteCustomer(customer))
            {
                ModelState.AddModelError("", "Something went wrong while deleting customer");
            }
            return Ok("Customer Deleted Successfully");
        }
    }
}
