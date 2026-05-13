using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Repositories;
using HealthcareAPI.Entities;
using HealthcareAPI.DTOs;

namespace HealthcareAPI.Services
{
    public interface IPatientService
    {
        Task CreatePatient(CreatePatientDto patient);
        Task <List<ReadPatientDto>> GetAllPatients();
        Task <ReadPatientDto> GetPatientById(int id);
        Task UpdatePatient (UpdatePatientDto patient);
        Task DeletePatient (int id);
    }
}
