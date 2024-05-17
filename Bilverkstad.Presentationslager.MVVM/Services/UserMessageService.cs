using System.Windows;

namespace Bilverkstad.Presentationslager.MVVM.Services
{
    public class UserMessageService : IUserMessageService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
