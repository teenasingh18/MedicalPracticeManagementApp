using Library.MedicalPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalPractice.Services;

public class PhysicianServiceProxy
{
    private List<Physicians?> physicians;

    private PhysicianServiceProxy()
    {
        physicians = new List<Physicians?>();
    }

    private static PhysicianServiceProxy? instance;
    private static object instanceLock = new object();

    public static PhysicianServiceProxy Current
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new PhysicianServiceProxy();
                }

                return instance;
            }
        }
    }

    public List<Physicians?> Physicians
    {
        get
        {
            return physicians;
        }

    }

    public Physicians? AddOrUpdatePhysician(Physicians? physician)
    {
        if (physician == null)
        {
            return null;
        }

        if (physician.physicianId <= 0)
        {
            var maxPhysicianId = -1;
            if (Physicians.Any())
            {
                maxPhysicianId = Physicians.Select(ph => ph?.physicianId ?? -1).Max();
            }

            else
            {
                maxPhysicianId = 0;
            }

            physician.physicianId = ++maxPhysicianId;

            Physicians.Add(physician);
        }

        return physician;
    }

    public Physicians? DeletePhysician(int id)
    {
        var PhysicianToDelete = physicians.Where(ph => ph != null).FirstOrDefault(ph => (ph?.physicianId ?? -1) == id);

        physicians.Remove(PhysicianToDelete);

        return PhysicianToDelete;
    }

}

