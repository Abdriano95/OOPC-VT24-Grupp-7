using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.MVVM.Commands;
using System.Windows.Input;
using Bilverkstad.Presentationslager.MVVM.Models;


namespace Bilverkstad.Presentationslager.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly Anställd _anställd;
        public MainViewModel() { }  
        public MainViewModel(Anställd anställd) 
        {
            _anställd = anställd;
        }
        private bool isModified = false;
        public bool IsModified { get { return isModified; } set { isModified = value; OnPropertyChanged(); } }

       

    }
    
}

