using Library.MedicalPractice.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.MedicalPractice.Models
{
    public class Appointments
    {
        public string? patientName {get; set;}
        public int patientId {get; set;}
        public string? physicianName {get; set;}
        public int physicianId {get; set;}
        public DateTime date {get; set;}

        public DateTime DateOnlyPart
        {
            get => date.Date;
            set => date = value.Date + date.TimeOfDay;
        }

        public TimeSpan TimeOnlyPart
        {
            get => date.TimeOfDay;
            set => date = date.Date + value;
        }

        public int appointmentId {get; set;}

        public string Display
        {
            get
            {
                return ToString();
            }
        }

        public override string ToString()
        {
            return $"{appointmentId} - {patientName} \n {physicianName} \n {date}";
        }

        public Appointments()
        {

        }
        public Appointments(int id)
        {
            var appointmentCopy = AppointmentServiceProxy.Current.Appointments.FirstOrDefault(a => (a?.appointmentId ?? 0) == id);

            if (appointmentCopy != null)
            {
                appointmentId = appointmentCopy.appointmentId;
                patientName = appointmentCopy.patientName;
                patientId = appointmentCopy.patientId;
                physicianName = appointmentCopy.physicianName;
                physicianId = appointmentCopy.physicianId;
                date = appointmentCopy.date;
            }
        }
    }
}
