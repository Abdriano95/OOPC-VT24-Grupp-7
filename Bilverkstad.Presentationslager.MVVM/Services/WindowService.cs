using System;
using System.Windows;
using System.Linq;
using System.Collections.Generic;

namespace Bilverkstad.Presentationslager.MVVM.Services
{
    public class WindowService : IWindowService
    {
        private readonly Dictionary<string, Type> windowTypeCache = new Dictionary<string, Type>();

        public void CloseWindow(string windowName)
        {
            var openWindows = Application.Current.Windows.OfType<Window>().Where(w => w.GetType().Name == windowName).ToList();
            foreach (var window in openWindows)
            {
                window.Close();
            }
        }

        public void OpenWindow(string windowName)
        {
            if (!windowTypeCache.TryGetValue(windowName, out Type? windowType))
            {
                windowType = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .FirstOrDefault(type => type.Name == windowName && type.IsSubclassOf(typeof(Window)));

                if (windowType != null)
                {
                    windowTypeCache[windowName] = windowType;
                }
                else
                {
                    throw new InvalidOperationException($"Window type '{windowName}' not found.");
                }
            }

            if (Activator.CreateInstance(windowType) is Window window)
            {
                window.Show();
            }
            else
            {
                throw new InvalidOperationException($"Window '{windowName}' could not be instantiated.");
            }
        }
    }
}
