using Library.MedicalPractice.Models;

namespace CLI.MedicalPracticeManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Medical Practice Management App!");
            List<Patients?> Patients = new List<Patients?>();
            List<Physicians?> Physicians = new List<Physicians?>();
            List<Appointments?> Appointments = new List<Appointments?>();

            bool cont = true;

            do
            {
                Console.WriteLine("A. Create a Patient");
                Console.WriteLine("B. List all Patients");
                Console.WriteLine("C. Update a Patient");
                Console.WriteLine("D. Delete a Patient");
                Console.WriteLine("E. Create a Physician");
                Console.WriteLine("F. List all Physisicans");
                Console.WriteLine("G. Update a Physician");
                Console.WriteLine("H. Delete a Physician");
                Console.WriteLine("I. Create an Appointment");
                Console.WriteLine("J. List all Appointments");
                Console.WriteLine("K. Update an Appointment");
                Console.WriteLine("L. Delete an Appointment");
                Console.WriteLine("Q. Quit");

                var userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "A":
                    case "a":
                        var patient = new Patients();
                        patient.name = Console.ReadLine();
                        patient.address = Console.ReadLine();
                        patient.birthdate = Console.ReadLine();
                        patient.race = Console.ReadLine();
                        patient.gender = Console.ReadLine();
                        patient.medicalNotes = Console.ReadLine();
                        patient.prescriptions = Console.ReadLine();
                        Patients.Add(patient);
                        break;
                    case "B":
                    case "b":
                        foreach (var p  in Patients)
                        {
                            Console.WriteLine(p);
                        }
                        break;
                    case "C":
                    case "c":
                        break;
                    case "D": 
                    case "d":
                        break;
                    case "E":
                    case "e":
                        var physician = new Physicians();
                        physician.name = Console.ReadLine();
                        physician.licenseNumber = Console.ReadLine();
                        physician.gradDate = Console.ReadLine();
                        physician.specializations = Console.ReadLine();

                        Physicians.Add(physician);
                        break;
                    case "F": 
                    case "f":
                        foreach (var ph in Physicians)
                        {
                            Console.WriteLine(ph);
                        }
                        break;
                    case "G":
                    case "g":
                        break;
                    case "H": 
                    case "h":
                        break;
                    case "I": 
                    case "i":
                        var appointment = new Appointments();
                        Appointments.Add(appointment);
                        break;
                    case "J":
                    case "j":
                        foreach (var a in Appointments)
                        {
                            Console.WriteLine(a);
                        }
                        break;
                    case "K":
                    case "k":
                        break;
                    case "L":
                    case "l":
                        break;
                    case "Q":
                    case "q":
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }
            } while (cont);
        }
    }
}
