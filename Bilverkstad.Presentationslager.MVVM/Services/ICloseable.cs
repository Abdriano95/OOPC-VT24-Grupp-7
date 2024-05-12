
namespace Bilverkstad.Presentationslager.MVVM.Services
{
    public interface ICloseable
    {
        void Close();
        bool? DialogResult { get; set; }
    }
}
