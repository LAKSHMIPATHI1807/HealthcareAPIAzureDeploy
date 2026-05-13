using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Entities;
using HealthcareAPI.Repositories;
using HealthcareAPI.Services;
using HealthcareAPI.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HealthcareAPI.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task CreatePatient(CreatePatientDto createpatientDto)
        {
            var patient = new Patient()
            {
                Name = createpatientDto.Name,
                Age = createpatientDto.Age,
                Gender = createpatientDto.Gender,
                ContactNumber = createpatientDto.ContactNumber,
                Address = createpatientDto.Address
            };
            await _patientRepository.CreatePatient(patient);
        }

        public async Task DeletePatient(int id)
        {
            await _patientRepository.DeletePatient(id);
        }

        public async Task<List<ReadPatientDto>> GetAllPatients()
        {
            var patients =await _patientRepository.GetAllPatients();
            return patients.Select(p => new ReadPatientDto()
            {
                PatientId = p.PatientId,
                Name = p.Name,
                Age = p.Age,
                ContactNumber = p.ContactNumber,
                Address = p.Address,
                Gender = p.Gender,
                CreatedDate = p.CreatedDate,

            }).ToList();
        }

        public async Task<ReadPatientDto> GetPatientById(int id)
        {
            var patient =await _patientRepository.GetPatientById(id);
            if (patient != null)
            {
                return new ReadPatientDto()
                {
                    PatientId = patient.PatientId,
                    Name = patient.Name,
                    Age = patient.Age,
                    ContactNumber = patient.ContactNumber,
                    Address = patient.Address,
                    Gender = patient.Gender,
                    CreatedDate = patient.CreatedDate,
                };
            }
            else
            {
                return null;
            }
        }

        public async Task UpdatePatient(UpdatePatientDto updatepatientDto)
        {
            var patient = new Patient()
            {
                PatientId = updatepatientDto.PatientId,
                Name = updatepatientDto.Name,
                Age = updatepatientDto.Age,
                ContactNumber = updatepatientDto.ContactNumber,
                Address = updatepatientDto.Address,
                Gender = updatepatientDto.Gender
            };
            await _patientRepository.UpdatePatient(patient);
        }
    }
}
