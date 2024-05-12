

namespace Bilverkstad.Presentationslager.MVVM.Commands
{
    public class MyCommands : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            // logik som returnerar "true" om Execute() får exekveras, annars "false"
            return true;
        }
        public override void Execute(object parameter)
        {
            // logik för kommandot (motsvarar en traditionell händelsehanetrare)
            Console.WriteLine("Command executed!");
        }
    }
}
