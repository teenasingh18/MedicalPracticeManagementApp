using Library.MedicalPractice.Models;
using Library.MedicalPractice.Services;
using Library.MedicalPractice.Utilities;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui.MedicalPracticeManagement.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly WebRequestHandler _patientsHandler = new WebRequestHandler();

        public MainViewModel()
        {
            SelectedAppointment = new Appointments
            {
                date = DateTime.Now
            };

            _ = LoadPatientsAsync();
        }

        private ObservableCollection<Patients?> _patients = new();
        public ObservableCollection<Patients?> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                NotifyPropertyChanged();
            }
        }

        public Patients? SelectedPatient { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        // Load patients from API
        public async Task LoadPatientsAsync()
        {
            var json = await _patientsHandler.Get("/patients");
            if (!string.IsNullOrEmpty(json))
            {
                var list = JsonConvert.DeserializeObject<List<Patients?>>(json);
                Patients = new ObservableCollection<Patients?>(list ?? new List<Patients?>());
            }
        }


        // Add or update patient via API
        public async Task AddOrUpdatePatientAsync(Patients patient)
        {
            var json = await _patientsHandler.Post("/patients", patient);

            // Refresh list after add/update
            await LoadPatientsAsync();
        }


        // Delete patient via API
        public async Task DeletePatientAsync()
        {
            if (SelectedPatient == null) return;

            await _patientsHandler.Delete($"/patients/{SelectedPatient.Id}");
            await LoadPatientsAsync();
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Physicians?> Physicians =>
            new ObservableCollection<Physicians?>(PhysicianServiceProxy.Current.Physicians);

        public Physicians? SelectedPhysician { get; set; }

        public void DeletePhysician()
        {
            if (SelectedPhysician == null) return;
            PhysicianServiceProxy.Current.DeletePhysician(SelectedPhysician.physicianId);
            NotifyPropertyChanged(nameof(Physicians));
        }

        public ObservableCollection<Appointments?> Appointments =>
            new ObservableCollection<Appointments?>(AppointmentServiceProxy.Current.Appointments);

        public Appointments? SelectedAppointment { get; set; }

        public void DeleteAppointment()
        {
            if (SelectedAppointment == null) return;
            AppointmentServiceProxy.Current.DeleteAppointment(SelectedAppointment.appointmentId);
            NotifyPropertyChanged(nameof(Appointments));
        }

        public void Refresh()
        {
            _ = LoadPatientsAsync();
            NotifyPropertyChanged(nameof(Physicians));
            NotifyPropertyChanged(nameof(Appointments));
        }
    }
}


