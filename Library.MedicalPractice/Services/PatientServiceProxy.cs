using Library.MedicalPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalPractice.Services;
public class PatientServiceProxy
{

    private List<Patients?> patients;

    private PatientServiceProxy() 
    { 
        patients = new List<Patients?>();
    }

    private static PatientServiceProxy? instance;
    private static object instanceLock = new object();

    public static PatientServiceProxy Current
    {
        get
        {
            lock (instanceLock)
            {

                if (instance == null)
                {
                    instance = new PatientServiceProxy();
                }

                return instance;
            }
        }
    }

    public List<Patients?> Patients
    {
        get
        {
            return patients;
        }
        
    }

    public Patients? AddOrUpdatePatient(Patients? patient)
    {
        if (patient == null)
        {
            return null;
        }

        if (patient.Id <= 0)
        {
            var maxId = -1;
            if (Patients.Any())
            {
                maxId = Patients.Select(p => p?.Id ?? -1).Max();
            }

            else
            {
                maxId = 0;
            }

            patient.Id = ++maxId;

            Patients.Add(patient);
        }

        return patient;
    }

    public Patients? DeletePatient (int id)
    {
        var patientToDelete = patients.Where(p => p != null).FirstOrDefault(p => (p?.Id ?? -1) == id);

        patients.Remove(patientToDelete);

        return patientToDelete;
    }
}

