using Library.MedicalPractice.Models;
using Library.MedicalPractice.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CLI.MedicalPracticeManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Medical Practice Management App!");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();

            List<Patients?> Patients = PatientServiceProxy.Current.Patients;
            List<Physicians?> Physicians = PhysicianServiceProxy.Current.Physicians;
            List<Appointments?> Appointments = AppointmentServiceProxy.Current.Appointments;

            bool cont = true;

            do
            {
                Console.WriteLine();
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
                Console.WriteLine();

                var userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "A":
                    case "a":
                        {

                            Console.WriteLine();

                            var patient = new Patients();

                            Console.WriteLine("Enter the birthdate of the patient (YYYY-MM-DD): ");
                            var birthday = Console.ReadLine();
                            if (DateOnly.TryParse(birthday, out var result))
                            {
                                patient.birthdate = result;
                            }

                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Wrong date format. Please try again");
                                Environment.Exit(0);

                            }

                            Console.WriteLine();
                            Console.WriteLine("Enter the name of the patient: ");
                            patient.name = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine("Enter the address of the patient: ");
                            patient.address = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine("Enter the race of the patient: ");
                            patient.race = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine("Enter the gender of the patient: ");
                            patient.gender = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine("Enter the medical notes of the patient: ");
                            patient.medicalNotes = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine("Enter the prescriptions of the patient: ");
                            patient.prescriptions = Console.ReadLine();

                            PatientServiceProxy.Current.AddOrUpdatePatient(patient);

                            Console.WriteLine();
                            Console.WriteLine("Patient has been added!");
                            break;
                        }
                        
                    case "B":
                    case "b":

                        Console.WriteLine();
                        PatientServiceProxy.Current.Patients.ForEach(Console.WriteLine);
                        Console.WriteLine();
                        break;

                    case "C":
                    case "c":
                        {
                            Console.WriteLine();

                            PatientServiceProxy.Current.Patients.ForEach(Console.WriteLine);
                            Console.WriteLine();
                            Console.WriteLine("Patient to update (ID): ");
                            var selection = Console.ReadLine();
                            var intSelection = int.Parse(selection ?? "0");
                            var PatientToUpdate = Patients.FirstOrDefault(p => (p?.Id ?? -1) == intSelection);

                            if(PatientToUpdate != null)
                            {

                                Console.WriteLine("Enter the birthdate of the patient (YYYY-MM-DD): ");
                                var birthday = Console.ReadLine();
                                if (DateOnly.TryParse(birthday, out var result))
                                {
                                    PatientToUpdate.birthdate = result;
                                }

                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Wrong date format. Please try again");
                                    Environment.Exit(1);
                                }

                                Console.WriteLine();
                                Console.WriteLine("Enter the name of the patient: ");
                                PatientToUpdate.name = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Enter the address of the patient: ");
                                PatientToUpdate.address = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Enter the race of the patient: ");
                                PatientToUpdate.race = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Enter the gender of the patient: ");
                                PatientToUpdate.gender = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Enter the medical notes of the patient: ");
                                PatientToUpdate.medicalNotes = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Enter the prescriptions of the patient: ");
                                PatientToUpdate.prescriptions = Console.ReadLine();
                            }

                            PatientServiceProxy.Current.AddOrUpdatePatient(PatientToUpdate);

                            Console.WriteLine();
                            Console.WriteLine("Patient has been updated!");
                            break;
                        }
                        
                    case "D": 
                    case "d":
                        {
                            Console.WriteLine();

                            Patients.ForEach(Console.WriteLine);
                            Console.WriteLine();
                            Console.WriteLine("Patient to delete (ID): ");
                            var selection = Console.ReadLine();

                            if (int.TryParse(selection, out var intSelection))
                            {
                                PatientServiceProxy.Current.DeletePatient(intSelection);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Patient has been deleted!");
                            break;
                        }
                       
                    case "E":
                    case "e":
                        {
                            Console.WriteLine();

                            var physician = new Physicians();

                            Console.WriteLine("Enter the graduation date of the physician (YYYY-MM-DD): ");
                            var grad = Console.ReadLine();
                            if (DateOnly.TryParse(grad, out var date))
                            {
                                physician.gradDate = date;
                            }

                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Wrong date format. Plese try again");
                                Environment.Exit(1);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Enter the name of the physician: ");
                            physician.name = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine("Enter the license number of the physician: ");
                            physician.licenseNumber = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine("Enter the specializations of the physician: ");
                            physician.specializations = Console.ReadLine();

                            PhysicianServiceProxy.Current.AddOrUpdatePhysician(physician);

                            Console.WriteLine();
                            Console.WriteLine("Physician has been added!");
                            break;
                        }
                        
                    case "F": 
                    case "f":
                        Console.WriteLine();
                        PhysicianServiceProxy.Current.Physicians.ForEach(Console.WriteLine);
                        Console.WriteLine();
                        break;
                    case "G":
                    case "g":
                        {
                            Console.WriteLine();

                            Physicians.ForEach(Console.WriteLine);
                            Console.WriteLine();
                            Console.WriteLine("Physician to update (ID): ");
                            Console.WriteLine();
                            var PhysicianSelection = Console.ReadLine();
                            var intPhySelection = int.Parse(PhysicianSelection ?? "0");
                            var PhysicianToUpdate = Physicians.FirstOrDefault(ph => (ph?.physicianId ?? -1) == intPhySelection);

                            if (PhysicianToUpdate != null)
                            {
                                Console.WriteLine("Enter the graduation date of the physician (YYYY-MM-DD): ");
                                var grad = Console.ReadLine();
                                if (DateOnly.TryParse(grad, out var date))
                                {
                                    PhysicianToUpdate.gradDate = date;
                                }

                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Wrong date format. Plese try again");
                                    Environment.Exit(1);
                                }

                                Console.WriteLine();
                                Console.WriteLine("Enter the name of the physician: ");
                                PhysicianToUpdate.name = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Enter the license number of the physician: ");
                                PhysicianToUpdate.licenseNumber = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Enter the specializations of the physician: ");
                                PhysicianToUpdate.specializations = Console.ReadLine();
                            }

                            PhysicianServiceProxy.Current.AddOrUpdatePhysician(PhysicianToUpdate);

                            Console.WriteLine();
                            Console.WriteLine("Physician has been updated!");
                            break;
                        }
                        
                    case "H": 
                    case "h":

                        {
                            Console.WriteLine();
                            Physicians.ForEach(Console.WriteLine);
                            Console.WriteLine();
                            Console.WriteLine("Physician to delete (ID): ");
                            Console.WriteLine();
                            var PhysicianSelection = Console.ReadLine();

                            if (int.TryParse(PhysicianSelection, out var intSelection))
                            {
                                PhysicianServiceProxy.Current.DeletePhysician(intSelection);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Physician has been deleted!");
                            break;
                        }
                        
                    case "I": 
                    case "i":

                        {
                            Console.WriteLine();
                            var appointment = new Appointments();

                            Console.WriteLine("Enter appointment date and time (yyyy-MM-dd HH:mm): ");
                            var input = Console.ReadLine();

                            DateTime apptTime;
                            if (DateTime.TryParse(input, out apptTime))
                            {

                                bool WeekDay = apptTime.DayOfWeek >= DayOfWeek.Monday && apptTime.DayOfWeek <= DayOfWeek.Friday;
                                TimeSpan start = new TimeSpan(8, 0, 0);
                                TimeSpan end = new TimeSpan(17, 0, 0);
                                TimeSpan time = apptTime.TimeOfDay;

                                if (WeekDay && time >= start && time <= end)
                                {
                                    appointment.date = apptTime;
                                }

                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Appointments can only be scheduled Monday–Friday between 8:00 AM and 5:00 PM.");
                                    Environment.Exit(1);
                                }
                            }

                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Invalid date / time format.Please try again.");
                                Environment.Exit(1);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Enter the name of the patient: ");
                            appointment.patientName = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine("Enter the ID number of the patient: ");
                            appointment.patientId = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine("Enter the name of the physician: ");
                            appointment.physicianName = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine("Enter the ID number of the physician: ");
                            appointment.physicianId = Console.ReadLine();

                            AppointmentServiceProxy.Current.AddOrUpdateAppt(appointment);

                            Console.WriteLine();
                            Console.WriteLine("Appointment has been booked!");
                            break;
                        }
                        
                    case "J":
                    case "j":
                        Console.WriteLine();
                        AppointmentServiceProxy.Current.Appointments.ForEach(Console.WriteLine);
                        Console.WriteLine();
                        break;

                    case "K":
                    case "k":

                        {
                            Console.WriteLine();
                            Appointments.ForEach(Console.WriteLine);
                            Console.WriteLine();
                            Console.WriteLine("Appointment to update (ID): ");
                            Console.WriteLine();
                            var appointmentSelection = Console.ReadLine();
                            var intApptSelection = int.Parse(appointmentSelection ?? "0");
                            var AppointmentToUpdate = Appointments.FirstOrDefault(a => (a?.appointmentId ?? -1) == intApptSelection);

                            if (AppointmentToUpdate != null)
                            {

                                Console.WriteLine("Enter appointment date and time (yyyy-MM-dd HH:mm): ");
                                var input = Console.ReadLine();

                                DateTime apptTime;
                                if (DateTime.TryParse(input, out apptTime))
                                {

                                    bool WeekDay = apptTime.DayOfWeek >= DayOfWeek.Monday && apptTime.DayOfWeek <= DayOfWeek.Friday;
                                    TimeSpan start = new TimeSpan(8, 0, 0);
                                    TimeSpan end = new TimeSpan(17, 0, 0);
                                    TimeSpan time = apptTime.TimeOfDay;

                                    if (WeekDay && time >= start && time <= end)
                                    {
                                        AppointmentToUpdate.date = apptTime;
                                    }

                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Appointments can only be scheduled Monday–Friday between 8:00 AM and 5:00 PM.");
                                    }
                                }

                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Invalid date / time format.Please try again.");
                                    Environment.Exit(1);
                                }

                                Console.WriteLine();
                                Console.WriteLine("Enter the name of the patient: ");
                                AppointmentToUpdate.patientName = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Enter the ID number of the patient: ");
                                AppointmentToUpdate.patientId = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Enter the name of the physician: ");
                                AppointmentToUpdate.physicianName = Console.ReadLine();

                                Console.WriteLine();
                                Console.WriteLine("Enter the ID number of the physician: ");
                                AppointmentToUpdate.physicianId = Console.ReadLine();
                            }

                            AppointmentServiceProxy.Current.AddOrUpdateAppt(AppointmentToUpdate);

                            Console.WriteLine();
                            Console.WriteLine("Appointment has been updated!");
                            break;
                        }
                        
                    case "L":
                    case "l":
                        {
                            Console.WriteLine();
                            Appointments.ForEach(Console.WriteLine);
                            Console.WriteLine();
                            Console.WriteLine("Appointment to delete (ID): ");
                            Console.WriteLine();
                            var appointmentSelection = Console.ReadLine();
                            

                            if (int.TryParse(appointmentSelection, out var intSelection))
                            {
                                AppointmentServiceProxy.Current.DeleteAppointment(intSelection);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Appointment has been deleted!");
                            break;
                        }
                        
                    case "Q":
                    case "q":
                        cont = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid Command");
                        break;
                }
            } while (cont);
        }
    }
}
