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
            Shell.Current.GoToAsync("//Patient");
        }

        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {
            (BindingContext as MainViewModel).Refresh();
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Delete();
        }
    }

}
