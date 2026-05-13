using HealthcareAPI.DTOs;
using HealthcareAPI.Entities;
using HealthcareAPI.Services;
using HealthcareAPI.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace HealthcareAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var patients = await _patientService.GetAllPatients();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Add(CreatePatientDto createPatientDto)
        {
            try
            {
                await _patientService.CreatePatient(createPatientDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePatient([FromRoute] int id)
        {
            try
            {
                await _patientService.DeletePatient(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpGet("Search/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var patient =await _patientService.GetPatientById(id);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, UpdatePatientDto updatePatientDto)
        {
            try
            {
                await _patientService.UpdatePatient(updatePatientDto);
                return Ok(updatePatientDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }
    }
}
