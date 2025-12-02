using Library.MedicalPractice.Services;

namespace Library.MedicalPractice.Models
{
    public class Patients
    {
        public string? name { get; set; }
        public string? address { get; set; }  
        public DateOnly birthdate { get; set; }
        public string? race { get; set; }
        public string? gender { get; set; }
        public string? medicalNotes { get; set; }
        public string? prescriptions { get; set; }
        public int Id { get; set; }

        public string Display
        {
            get
            {
                return ToString();
            }
        }
        public override string ToString()
        {
            return $" {Id} - {name} \n {address} \n {birthdate} \n {race} \n {gender} \n {medicalNotes} \n {prescriptions}";
        }

        public Patients ()
        {

        }
        public Patients(int id)
        {
            var patientCopy = PatientServiceProxy.Current.Patients.FirstOrDefault(p => (p?.Id ?? 0) == id);

            if (patientCopy != null)
            {
                Id = patientCopy.Id;
                name = patientCopy.name;
                address = patientCopy.address;
                birthdate = patientCopy.birthdate;
                race = patientCopy.race;
                gender = patientCopy.gender;
                medicalNotes = patientCopy.medicalNotes;
                prescriptions = patientCopy.prescriptions;
            }
        }
    }
}
