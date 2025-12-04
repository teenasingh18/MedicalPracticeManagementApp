using Library.MedicalPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Api.MedicalPractice.Database;

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
        public IEnumerable<Patients> Get()
        {
            return Filebase.Current.Patients;
        }

        // READ BY ID
        [HttpGet("{id}")]
        public Patients? GetById(int id)
        {
            return Filebase.Current.Patients.FirstOrDefault(p => p.Id == id);
        }

        // CREATE or UPDATE
        [HttpPost]
        public Patients AddOrUpdate([FromBody] Patients patient)
        {
            return Filebase.Current.AddOrUpdate(patient);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = Filebase.Current.Delete(id);
            if (!success) return NotFound();
            return Ok();
        }

        // SEARCH
        [HttpGet("search")]
        public IEnumerable<Patients> Search([FromQuery] string query)
        {
            var term = query?.ToLower() ?? string.Empty;
            return Filebase.Current.Patients
                .Where(p =>
                    (p.name ?? "").ToLower().Contains(term) ||
                    (p.address ?? "").ToLower().Contains(term) ||
                    (p.race ?? "").ToLower().Contains(term) ||
                    (p.gender ?? "").ToLower().Contains(term) ||
                    (p.medicalNotes ?? "").ToLower().Contains(term) ||
                    (p.prescriptions ?? "").ToLower().Contains(term));
        }
    }
}


