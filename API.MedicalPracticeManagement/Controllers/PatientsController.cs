using Library.MedicalPractice.Models;
using Library.MedicalPractice.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.MedicalPractice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<PatientsController> _logger;

        public PatientsController(ILogger<PatientsController> logger)
        {
            _logger = logger;
        }

        // READ ALL
        [HttpGet]
        public IEnumerable<Patients?> Get()
        {
            return PatientServiceProxy.Current.Patients;
        }

        // READ BY ID
        [HttpGet("{id}")]
        public Patients? GetById(int id)
        {
            return PatientServiceProxy.Current.Patients
                .FirstOrDefault(p => p?.Id == id);
        }

        // CREATE or UPDATE
        [HttpPost]
        public Patients? AddOrUpdate([FromBody] Patients patient)
        {
            return PatientServiceProxy.Current.AddOrUpdatePatient(patient);
        }

        // DELETE
        [HttpDelete("{id}")]
        public Patients? Delete(int id)
        {
            return PatientServiceProxy.Current.DeletePatient(id);
        }

        // SEARCH (simple query against multiple fields)
        [HttpPost("Search")]
        public IEnumerable<Patients?> Search([FromBody] QueryRequest query)
        {
            var term = query.Content?.ToLower() ?? string.Empty;

            return PatientServiceProxy.Current.Patients
                .Where(p => p != null &&
                            ((p.name ?? "").ToLower().Contains(term) ||
                             (p.address ?? "").ToLower().Contains(term) ||
                             (p.race ?? "").ToLower().Contains(term) ||
                             (p.gender ?? "").ToLower().Contains(term) ||
                             (p.medicalNotes ?? "").ToLower().Contains(term) ||
                             (p.prescriptions ?? "").ToLower().Contains(term)));
        }
    }

    // Simple DTO for search requests
    public class QueryRequest
    {
        public string? Content { get; set; }
    }
}

