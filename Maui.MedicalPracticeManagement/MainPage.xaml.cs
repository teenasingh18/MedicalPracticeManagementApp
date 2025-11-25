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

        }
    }

}
