using Maui.MedicalPracticeManagement.ViewModels;

namespace Maui.MedicalPracticeManagement
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }


        private void AddClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Patient?patientId=0");
        }

        private async void DeleteClicked(object sender, EventArgs e)
        {
            var vm = BindingContext as MainViewModel;
            if (vm != null)
            {
                await vm.DeletePatientAsync();
            }

        }

        private void EditClicked(object sender, EventArgs e)
        {
            var selectedId = (BindingContext as MainViewModel)?.SelectedPatient?.Id ?? 0;
            Shell.Current.GoToAsync($"//Patient?patientId={selectedId}");
        }

        private void AddPhysicianClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Physician?physicianId=0");
        }

      
        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {
            var vm = BindingContext as MainViewModel;
            vm?.Refresh();
        }

        private void DeletePhysicianClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel)?.DeletePhysician();
        }

        private void EditPhysicianClicked(object sender, EventArgs e)
        {
            var selectedId = (BindingContext as MainViewModel)?.SelectedPhysician?.physicianId ?? 0;
            Shell.Current.GoToAsync($"//Physician?physicianId={selectedId}");
        }

        private void AddAppointmentClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Appointment?appointmentId=0");
        }

        private void EditAppointmentClicked(object sender, EventArgs e)
        {
            var selectedId = (BindingContext as MainViewModel)?.SelectedAppointment?.appointmentId ?? 0;
            Shell.Current.GoToAsync($"//Appointment?appointmentId={selectedId}");
        }

        private void DeleteAppointmentClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel)?.DeleteAppointment();
        }
    }

}
