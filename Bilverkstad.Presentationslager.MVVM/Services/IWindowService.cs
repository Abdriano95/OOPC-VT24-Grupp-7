namespace Bilverkstad.Presentationslager.MVVM.Services
{
    public interface IWindowService
    {
        void OpenWindow(string windowName);
        void CloseWindow(string windowName);
    }
}
