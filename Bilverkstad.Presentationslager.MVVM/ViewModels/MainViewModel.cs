using Bilverkstad.Entitetlagret;
using Bilverkstad.Presentationslager.Commands;
using Bilverkstad.Presentationslager.Models;
using Bilverkstad.Presentationslager.Services;

using System.Windows.Input;

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

        private ICommand closeCommand = null!;
        public ICommand CloseCommand => closeCommand ??= closeCommand = new RelayCommand<ICloseable>((closeable) =>
        {
                closeable.Close();  
        });

    }
    
}

