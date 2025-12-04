using Library.MedicalPractice.Models;
using Library.MedicalPractice.Services;

namespace Maui.MedicalPracticeManagement.Views;

[QueryProperty(nameof(PatientId),"patientId")]

public partial class PatientView : ContentPage
{
	public PatientView()
	{
		InitializeComponent();
	}

	public int PatientId { get; set; }

	private void CancelClicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//MainPage");
    }

    private async void OkClicked(object sender, EventArgs e)
    {
        var patient = BindingContext as Patients;
        if (patient != null)
        {
            var vm = new ViewModels.MainViewModel();
            await vm.AddOrUpdatePatientAsync(patient);
        }

        // Go back to the main page
        await Shell.Current.GoToAsync("//MainPage");
    }

    private async void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if (PatientId == 0)
        {
            BindingContext = new Patients();
        }
        else
        {
            // Fetch patient from API
            var handler = new Library.MedicalPractice.Utilities.WebRequestHandler();
            var json = await handler.Get($"/patients/{PatientId}");
            if (!string.IsNullOrEmpty(json))
            {
                var patient = Newtonsoft.Json.JsonConvert.DeserializeObject<Patients>(json);
                BindingContext = patient ?? new Patients();
            }
        }
    }
}