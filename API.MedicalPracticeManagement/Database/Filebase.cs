using Library.MedicalPractice.Models;
using Newtonsoft.Json;

namespace Api.MedicalPractice.Database
{
    public class Filebase
    {
        private string _root;
        private string _patientRoot;
        private static Filebase _instance;

        public static Filebase Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Filebase();
                }
                return _instance;
            }
        }

        private Filebase()
        {
            _root = @"C:\temp";
            _patientRoot = $"{_root}\\Patients";

            // Ensure directory exists
            if (!Directory.Exists(_patientRoot))
            {
                Directory.CreateDirectory(_patientRoot);
            }
        }

        public int LastPatientKey
        {
            get
            {
                if (Patients.Any())
                {
                    return Patients.Select(x => x.Id).Max();
                }
                return 0;
            }
        }

        public Patients AddOrUpdate(Patients patient)
        {
            // Assign new Id if needed
            if (patient.Id <= 0)
            {
                patient.Id = LastPatientKey + 1;
            }

            string path = $"{_patientRoot}\\{patient.Id}.json";

            // If file exists, overwrite
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(patient, Formatting.Indented));

            return patient;
        }

        public List<Patients> Patients
        {
            get
            {
                var root = new DirectoryInfo(_patientRoot);
                var patients = new List<Patients>();

                foreach (var patientFile in root.GetFiles("*.json"))
                {
                    var patient = JsonConvert.DeserializeObject<Patients>(File.ReadAllText(patientFile.FullName));
                    if (patient != null)
                    {
                        patients.Add(patient);
                    }
                }
                return patients;
            }
        }

        public bool Delete(int id)
        {
            string path = $"{_patientRoot}\\{id}.json";
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
    }
}

