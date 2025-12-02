using Library.MedicalPractice.Models;
using Library.MedicalPractice.Services;
using Maui.MedicalPracticeManagement.ViewModels;

namespace Maui.MedicalPracticeManagement.Views;

[QueryProperty(nameof(AppointmentId), "appointmentId")]

public partial class AppointmentView : ContentPage
{
	public AppointmentView()
	{
		InitializeComponent();
        BindingContext = new MainViewModel();
    }

    public int AppointmentId { get; set; }

    public List<Patients?> Patients => PatientServiceProxy.Current.Patients;
    public List<Physicians?> Physicians => PhysicianServiceProxy.Current.Physicians;

    public Patients? SelectedPatient { get; set; }
    public Physicians? SelectedPhysician { get; set; }

    private void CancelApptClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OkApptClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as MainViewModel;
        if (vm?.SelectedPatient == null || vm?.SelectedPhysician == null)
        {
            DisplayAlert("Error", "Please select both a patient and a physician.", "OK");
            return;
        }


        var appt = vm.SelectedAppointment;
        if (appt == null)
        {
            appt = new Appointments
            {
                date = DateTime.Now
            };
            vm.SelectedAppointment = appt;
        }

        appt.patientId = vm.SelectedPatient.Id;
        appt.patientName = vm.SelectedPatient.name;
        appt.physicianId = vm.SelectedPhysician.physicianId;
        appt.physicianName = vm.SelectedPhysician.name;
        appt.date = vm.SelectedAppointment.date;

        if (!AppointmentServiceProxy.ValidateAppointment(appt))
        {
            DisplayAlert("Invalid Appointment",
                "Check that:\n- Patient and Physician exist\n- Date is Mon–Fri, 8AM–5PM\n- No double booking",
                "OK");
            return;
        }

        AppointmentServiceProxy.Current.AddOrUpdateAppt(appt);
        Shell.Current.GoToAsync("//MainPage");

    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if (AppointmentId == 0)
        {
            BindingContext = new Appointments
            {
                date = DateTime.Now 
            };

        }
        else
        {
            BindingContext = new Appointments(AppointmentId);
        }

    }
}