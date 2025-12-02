using Library.MedicalPractice.Models;
using Library.MedicalPractice.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Maui.MedicalPracticeManagement.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            SelectedAppointment = new Appointments
            {
                date = DateTime.Now
            };
        }
    
        public ObservableCollection<Patients?> Patients
        {
            get
            {
                return new ObservableCollection<Patients?>(PatientServiceProxy.Current.Patients);
            }
        }

        public Patients? SelectedPatient
        {
            get; set;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Delete()
        {
            if (SelectedPatient == null)
            {
                return;
            }

            PatientServiceProxy.Current.DeletePatient(SelectedPatient.Id);
            NotifyPropertyChanged("Patients");
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Physicians?> Physicians
        {
            get
            {
                return new ObservableCollection<Physicians?>(PhysicianServiceProxy.Current.Physicians);
            }
        }

        public Physicians? SelectedPhysician
        {
            get; set;
        }


        public void DeletePhysician()
        {
            if (SelectedPhysician == null)
            {
                return;
            }

            PhysicianServiceProxy.Current.DeletePhysician(SelectedPhysician.physicianId);
            NotifyPropertyChanged("Physicians");
        }

        public ObservableCollection<Appointments?> Appointments
        {
            get
            {
                return new ObservableCollection<Appointments?>(AppointmentServiceProxy.Current.Appointments);
            }
        }

        public Appointments? SelectedAppointment
        {
            get; set;
        }


        public void DeleteAppointment()
        {
            if (SelectedAppointment == null)
            {
                return;
            }

            AppointmentServiceProxy.Current.DeleteAppointment(SelectedAppointment.appointmentId);
            NotifyPropertyChanged("Appointments");
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Patients));
            NotifyPropertyChanged(nameof(Physicians));
            NotifyPropertyChanged(nameof(Appointments));
        }
    }

}
