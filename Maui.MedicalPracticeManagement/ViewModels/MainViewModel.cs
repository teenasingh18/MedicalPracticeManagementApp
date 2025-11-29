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
        public ObservableCollection<Patients?> Patients
        {
            get
            {
                return new ObservableCollection<Patients?>(PatientServiceProxy.Current.Patients);
            }
        }

        public void Refresh()
        {
            NotifyPropertyChanged("Patients");
        }
        public Patients? SelectedPatient
        {
            get; set;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
