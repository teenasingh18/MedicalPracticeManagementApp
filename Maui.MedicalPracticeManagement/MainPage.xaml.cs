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

        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {
            (BindingContext as MainViewModel)?.Refresh();
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel)?.Delete();
        }

        private void EditClicked(object sender, EventArgs e)
        {
            var selectedId = (BindingContext as MainViewModel)?.SelectedPatient?.Id ?? 0;
            Shell.Current.GoToAsync($"//Patient?patientId={selectedId}");
        }
    }

}
