
using Autofac;
using Bilverkstad.Presentationslager.Data;
using Bilverkstad.Presentationslager.ViewModel;
using System.ComponentModel;
using IContainer = Autofac.IContainer;

namespace Bilverkstad.Presentationslager.Startup
{
    public class Bootstraper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<KundDataService>().As<IKundDataService>();
            return builder.Build();
        }
    }
}
