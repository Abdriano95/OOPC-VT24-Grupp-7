using System.Windows;

namespace Bilverkstad.Presentationslager.MVVM.Services
{
    public class UserMessageService : IUserMessageService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public UserMessageResult ShowMessage(string message, string caption, UserMessageButtons buttons)
        {
            MessageBoxResult result = MessageBoxResult.None;

            switch (buttons)
            {
                case UserMessageButtons.JaNej:
                    result = MessageBox.Show(message, caption, MessageBoxButton.YesNo);
                    break;
                    
            }

            return result == MessageBoxResult.Yes ? UserMessageResult.Ja : UserMessageResult.Nej;
        }
    }
}
