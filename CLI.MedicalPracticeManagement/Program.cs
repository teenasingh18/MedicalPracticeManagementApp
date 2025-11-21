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
                        Patients.ForEach(Console.WriteLine);
                        Console.WriteLine("Patient to delete (ID): ");
                        var selection = Console.ReadLine();
                        var intSelection = int.Parse(selection ?? "0");
                        var PatientToDelete = Patients.FirstOrDefault(p => (p?.Id ?? -1) == intSelection);

                        Patients.Remove(PatientToDelete);

                        break;
                    case "E":
                    case "e":
                        var physician = new Physicians();
                        physician.name = Console.ReadLine();
                        physician.licenseNumber = Console.ReadLine();
                        physician.gradDate = Console.ReadLine();
                        physician.specializations = Console.ReadLine();

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

                        Physicians.ForEach(Console.WriteLine);
                        Console.WriteLine("Physician to delete (ID): ");
                        var PhysicianSelection = Console.ReadLine();
                        var intPhySelection = int.Parse(PhysicianSelection ?? "0");
                        var PhysicianToDelete = Physicians.FirstOrDefault(ph => (ph?.physicianId ?? -1) == intPhySelection);

                        Physicians.Remove(PhysicianToDelete);
                        break;
                    case "I": 
                    case "i":
                        var appointment = new Appointments();
                        appointment.patientName = Console.ReadLine();
                        appointment.patientId = Console.ReadLine();
                        appointment.physicianName = Console.ReadLine();
                        appointment.physicianId = Console.ReadLine();
                        appointment.date = Console.ReadLine();

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
                        Appointments.ForEach(Console.WriteLine);
                        Console.WriteLine("Appointment to delete (ID): ");
                        var appointmentSelection = Console.ReadLine();
                        var intApptSelection = int.Parse(appointmentSelection ?? "0");
                        var AppointmentToDelete = Appointments.FirstOrDefault(a => (a?.appointmentId ?? -1) == intApptSelection);

                        Appointments.Remove(AppointmentToDelete);
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
