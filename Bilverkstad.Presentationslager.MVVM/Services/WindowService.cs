using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bilverkstad.Presentationslager.Services
{
    public class WindowService : IWindowService
    {
        private static Dictionary<Type, Type> mappings = new Dictionary<Type, Type>();
        private Dictionary<object, Window> openWindows = new Dictionary<object, Window>();

        public static void RegisterWindow<TViewModel, TView>()
            where TViewModel : new()
            where TView : Window
        {
            mappings[typeof(TViewModel)] = typeof(TView);
        }

        private Window CreateWindow<TViewModel>(TViewModel model)
        {
            if (mappings.TryGetValue(typeof(TViewModel), out Type view))
            {
                if (Activator.CreateInstance(view) is Window window)
                {
                    if (model != null)
                        window.DataContext = model;
                    return window;
                }
            }
            return null;
        }

        public void Show<TViewModel>(TViewModel model)
        {
            CreateWindow<TViewModel>(model)?.Show();
        }

        public bool ShowDialog<TViewModel>(TViewModel model)
        {
            return CreateWindow<TViewModel>(model)?.ShowDialog() ?? false;
        }

        public void CloseWindow<TViewModel>(TViewModel model)
        {
            if (openWindows.TryGetValue(model, out Window window))
            {
                window.Close();
                openWindows.Remove(model); // Optionally remove the window from the dictionary upon closing
            }
        }
    }
}
