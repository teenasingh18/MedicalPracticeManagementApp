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
        public int patientId {get; set;}
        public string? physicianName {get; set;}
        public int physicianId {get; set;}
        public DateTime date {get; set;}

        public int appointmentId {get; set;}

        public override string ToString()
        {
            return $"{appointmentId} - {patientName} \n {physicianName} \n {date}";
        }
    }
}
