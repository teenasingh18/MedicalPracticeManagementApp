using Library.MedicalPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.MedicalPracticeManagement.ViewModels
{
    public class MainViewModel
    {
        public List<Patients> Patients
        {
            get
            {
                return new List<Patients>
                {
                    new Patients {Id = 1, name = "Teena Singh",
                    address = "1800 W Pensacola St",
                    birthdate = new DateOnly(2003,11,18), race = "white", gender = "female",
                    medicalNotes = "na", prescriptions = "na"},

                    new Patients {Id = 2, name = "Ana Briceño",
                    address = "1800 W Pensacola St",
                    birthdate = new DateOnly(2003,09,13), race = "white", gender = "female",
                    medicalNotes = "na", prescriptions = "na"},

                    new Patients {Id = 3, name = "Valentina Fernandez",
                    address = "1800 W Pensacola St",
                    birthdate = new DateOnly(2004,02,28), race = "white", gender = "female",
                    medicalNotes = "na", prescriptions = "na"}
                };
            }
        }

        public Patients? SelectedPatient
        {
            get; set;
        }
    }

}
