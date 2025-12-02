using Library.MedicalPractice.Models;
using Library.MedicalPractice.Services;

namespace Maui.MedicalPracticeManagement.Views;

[QueryProperty(nameof(PhysicianId), "physicianId")]

public partial class PhysicianView : ContentPage
{
	public PhysicianView()
	{
		InitializeComponent();
	}

    public int PhysicianId { get; set; }

    private void CancelPhysicianClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OkPhysicianClicked(object sender, EventArgs e)
    {
        //add the patient
        PhysicianServiceProxy.Current.AddOrUpdatePhysician(BindingContext as Physicians);

        //go back to the main page
        Shell.Current.GoToAsync("//MainPage");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if (PhysicianId == 0)
        {
            BindingContext = new Physicians();
        }
        else
        {
            BindingContext = new Physicians(PhysicianId);
        }

    }
}




    

    
