using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Entities;
using HealthcareAPI.Repositories;
using HealthcareAPI.Database;

namespace HealthcareAPI.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _appDbContext;
        public PatientRepository(AppDbContext appDb)
        {
            _appDbContext = appDb;
        }

        public async Task CreatePatient(Patient patient)
        {
            _appDbContext.Patients.Add(patient);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeletePatient(int id)
        {
            var patient = _appDbContext.Patients.FirstOrDefault(p => p.PatientId == id);
            if (patient != null)
            {
                _appDbContext.Remove(patient);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _appDbContext.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            var patient =await _appDbContext.Patients.FindAsync(id);
            return patient;
        }

        public async Task UpdatePatient(Patient patient)
        {
            _appDbContext.Patients.Update(patient);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
