using Library.MedicalPractice.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalPractice.Models
{
    public class Physicians
    {
        public string? name {  get; set; }
        public string? licenseNumber { get; set; }
        public DateTime gradDate { get; set; }
        public string? specializations { get; set; }

        public int physicianId { get; set; }

        public string Display
        {
            get
            {
                return ToString();
            }
        }

        public override string ToString()
        {
            return $"{physicianId} - {name} \n {licenseNumber} \n {gradDate.ToString("MM/dd/yyyy")} \n {specializations}";
        }

        public Physicians()
        {

        }
        public Physicians(int id)
        {
            var physicianCopy = PhysicianServiceProxy.Current.Physicians.FirstOrDefault(ph => (ph?.physicianId ?? 0) == id);

            if (physicianCopy != null)
            {
                name = physicianCopy.name;
                licenseNumber = physicianCopy.licenseNumber;
                gradDate = physicianCopy.gradDate;
                physicianId = physicianCopy.physicianId;
            }
        }
    }
}
