using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using zieschang.net.Projects.OnScreenKeyboardDisabler.Native.ViewModel;

namespace zieschang.net.Projects.OnScreenKeyboardDisabler.Native
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView<zieschang.net.Projects.OnScreenKeyboardDisabler.Native.ViewModel.KeyboardServiceViewModel>
    {
        public zieschang.net.Projects.OnScreenKeyboardDisabler.Native.ViewModel.KeyboardServiceViewModel Model
        {
            get { return (zieschang.net.Projects.OnScreenKeyboardDisabler.Native.ViewModel.KeyboardServiceViewModel)this.DataContext; }

            set
            {
                this.DataContext = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Model = new KeyboardServiceViewModel();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Model.ChangeServiceState();
        }
    }
}
