using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Entities;

namespace HealthcareAPI.Repositories
{
    public interface IPatientRepository
    {
        Task CreatePatient(Patient patient);
        Task <List<Patient>> GetAllPatients();
        Task <Patient> GetPatientById(int id);
        Task UpdatePatient(Patient patient);
        Task DeletePatient(int id);
    }
}
