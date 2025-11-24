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
    public static AppointmentServiceProxy Current
    {
        get
        {
            if (instance == null)
            {
                instance = new AppointmentServiceProxy();
            }

            return instance;

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

            Appointments.Add(appointment);
        }

        return appointment;
    }

    public Appointments? DeleteAppointment(int id)
    {
        var AppointmentToDelete = appointments.Where(a => a != null).FirstOrDefault(a => (a?.appointmentId ?? -1) == id);

        appointments.Remove(AppointmentToDelete);

        return AppointmentToDelete;
    }
}

