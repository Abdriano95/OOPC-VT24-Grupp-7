namespace Bilverkstad.Presentationslager.MVVM.Services
{
    public interface IUserMessageService
    {
        void ShowMessage(string message);
        UserMessageResult ShowMessage(string message, string caption, UserMessageButtons buttons);
    }

    public enum UserMessageResult
    {
        Ja,
        Nej
    }

    public enum UserMessageButtons
    {
        JaNej
    }

}
