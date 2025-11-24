using Library.MedicalPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalPractice.Services;

public class AppointmentServiceProxy
{
    private List<Appointments?> appointments;

    private AppointmentServiceProxy()
    {
        appointments = new List<Appointments?>();
    }

    private static AppointmentServiceProxy? instance;
    private static object instanceLock = new object();
    public static AppointmentServiceProxy Current
    {
        get
        {
            lock(instanceLock)
            {
                if (instance == null)
                {
                    instance = new AppointmentServiceProxy();
                }

                return instance;
            }

        }
    }

    public List<Appointments?> Appointments
    {
        get
        {
            return appointments;
        }

    }

    public Appointments? AddOrUpdateAppt(Appointments? appointment)
    {
        if (appointment == null)
        {
            return null;
        }

        if (appointment.appointmentId <= 0)
        {
            var maxApptId = -1;

            if (Appointments.Any())
            {
                maxApptId = Appointments.Select(a => a?.appointmentId ?? -1).Max();
            }

            else
            {
                maxApptId = 0;
            }

            appointment.appointmentId = ++maxApptId;

            if (ValidateAppointment(appointment))
            {
                Appointments.Add(appointment);
                Console.WriteLine("Appointment has been created!");

            }
        }

        return appointment;
    }

    public Appointments? DeleteAppointment(int id)
    {
        var AppointmentToDelete = appointments.Where(a => a != null).FirstOrDefault(a => (a?.appointmentId ?? -1) == id);

        appointments.Remove(AppointmentToDelete);

        return AppointmentToDelete;
    }

    public static bool ValidateAppointment(Appointments? appt)
    {

        if (appt == null)
        {
            return false;
        }

        //check if patient and physician exist
        var PatientExists = PatientServiceProxy.Current.Patients
            .Any(p => p != null && p.Id == appt?.patientId);

        var PhysicianExists = PhysicianServiceProxy.Current.Physicians
            .Any(ph => ph != null && ph.physicianId == appt?.physicianId);

        if (!PatientExists || !PhysicianExists)
        {
            Console.WriteLine("The Patient or the Physician are not registered in the program");
            return false;
        }

        if (appt != null)
        {
            // check weekday and hours
            bool weekday = appt?.date.DayOfWeek >= DayOfWeek.Monday &&
            appt.date.DayOfWeek <= DayOfWeek.Friday;

      
            TimeSpan start = new TimeSpan(8, 0, 0);
            TimeSpan end = new TimeSpan(17, 0, 0);
            TimeSpan time = appt.date.TimeOfDay;


            if (!(weekday && time >= start && time <= end))
            {
                Console.WriteLine("Appointments can only be scheduled Monday through Friday from 8AM-5PM");
                return false;
            }
        }

        //check double booking
        var conflicts = AppointmentServiceProxy.Current.Appointments
            .Any(a => a != null && ((a.patientId == appt?.patientId) ||
            (a.physicianId == appt?.physicianId)) && a.date == appt?.date);

        if (conflicts)
        {
            Console.WriteLine("The Patient or the Physician already have an appoinment at this time");
            return false;
        }

        return true;
    }
}

