using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wellness_Score_API.Interfaces;
using Wellness_Score_API.Models;

namespace Wellness_Score_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        IDiagnosisRepository _diagnosisRepository;
        ICustomerRepository _customerRepository;
        public DiagnosisController(IDiagnosisRepository diagnosisRepository, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _diagnosisRepository = diagnosisRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiagnosis(int id)
        {
            var diagnosis = _diagnosisRepository.GetDiagnosis(id);
            if (diagnosis == null)
                return NotFound("Data Not Found");
            return Ok(diagnosis);
        }

        [HttpPost]
        public async Task<IActionResult> AddDiagnosis([FromBody]Diagnosis diagnosis)
        {
            if (diagnosis == null)
                return BadRequest();
            if (!_diagnosisRepository.AddDiagnosis(diagnosis))
            {
                ModelState.AddModelError("", "Something went wrong while updating customer");
                return StatusCode(StatusCodes.Status500InternalServerError,ModelState);
            }
            return Ok("Successfully added Diagnosis Details");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnosis(int id)
        {
            if (id == 0)
                return BadRequest();
            if (!_diagnosisRepository.DiagnosisExists(id))
                return NotFound();
            if (!_diagnosisRepository.DeleteDiagnosis(id))
            {
                ModelState.AddModelError("", "Something went wrong while updating customer");
                return StatusCode(StatusCodes.Status500InternalServerError,ModelState);
            }
            return Ok("Successfully deleted");
        }
        [HttpPut]
        public IActionResult EditDiagnosis([FromBody] Diagnosis UpdateDiagnosis)
        {
            if (UpdateDiagnosis == null) return BadRequest(ModelState);

            if (!_diagnosisRepository.DiagnosisExists(UpdateDiagnosis.Id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_diagnosisRepository.EditDiagnosis(UpdateDiagnosis))
            {
                ModelState.AddModelError("", "Something went wrong while updating customer");
                return StatusCode(500, ModelState);
            }
            return Ok("Diagnosis Updated Successfully");
        }
        //[HttpPut]
        //public async Task<IActionResult> EditDiadnosi([FromBody] Diagnosis diagnosis)
        //{
        //    if (diagnosis == null)
        //        return BadRequest();
        //    if (_diagnosisRepository.GetDiagnosis(diagnosis.Id) == null)
        //        return NotFound();
        //    if (_diagnosisRepository.EditDiagnosis(diagnosis))
        //        return Ok("Successfull Edited ");
        //    return StatusCode(StatusCodes.Status500InternalServerError);
        //}
        [HttpGet]
        public IActionResult GetWellnessScore(int customerid)
        {
            if(customerid == null) return BadRequest(ModelState);

            if(!_customerRepository.CustomerExists(customerid)) return NotFound();

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var customer = _customerRepository.GetCustomerById(customerid);
            var wellnessScore = customer.Diagnosis.WellnessScore;

            return Ok(wellnessScore);
        }

    }
}