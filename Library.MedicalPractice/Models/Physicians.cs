using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.MedicalPractice.Models
{
    public class Physicians
    {
        public string? name {  get; set; }
        public string? licenseNumber { get; set; }
        public string? gradDate { get; set; }
        public string? specializations { get; set; }

        public override string ToString()
        {
            return $"{name} \n {licenseNumber} \n {gradDate} \n {specializations}";
        }
    }
}
