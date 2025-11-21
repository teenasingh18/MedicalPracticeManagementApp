using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalPractice.Models
{
    public class Appointments
    {
        public string? patientName {get; set;}
        public string? patientId {get; set;}
        public string? physicianName {get; set;}
        public string? physicianId {get; set;}
        public string? date {get; set;}

        public override string ToString()
        {
            return $"{patientName} \n {physicianName} \n {date}";
        }
    }
}
