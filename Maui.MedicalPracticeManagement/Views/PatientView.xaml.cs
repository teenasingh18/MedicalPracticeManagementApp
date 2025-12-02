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

	private void OkClicked(object sender, EventArgs e)
	{
		//add the patient
		PatientServiceProxy.Current.AddOrUpdatePatient(BindingContext as Patients);

		//go back to the main page
		Shell.Current.GoToAsync("//MainPage");
	}

	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		if (PatientId == 0)
		{
            BindingContext = new Patients();
        }
		else
		{
			BindingContext = new Patients(PatientId);
		}

    }
}