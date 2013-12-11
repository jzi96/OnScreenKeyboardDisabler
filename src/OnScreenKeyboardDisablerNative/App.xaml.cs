using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using zieschang.net.Projects.OnScreenKeyboardDisabler.Native.ViewModel;

namespace zieschang.net.Projects.OnScreenKeyboardDisabler.Native
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
        protected override void OnLoadCompleted(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnLoadCompleted(e);
        }
    }
}
