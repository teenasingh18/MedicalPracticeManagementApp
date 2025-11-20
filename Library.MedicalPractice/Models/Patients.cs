namespace Library.MedicalPractice.Models
{
    public class Patients
    {
        public string? name { get; set; }
        public string? address { get; set; }  
        public string? birthdate { get; set; }
        public string? race { get; set; }
        public string? gender { get; set; }
        public string? medicalNotes { get; set; }
        public string? prescriptions { get; set; }
        public int Id { get; set; }

    }
}
