using System;
using System.Collections.Generic;
using System.IO;
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

namespace WritePadPreviewInstaller.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy StartPage.xaml
    /// </summary>
    public partial class InstallationPage : Page
    {
        public InstallationPage()
        {
            InitializeComponent();
            InstallationPlan();

        }
        private async void InstallationPlan()
        {
            ProgressTextBox.Text = "Checking the package...";
            InstallationProgressBar.Value = 10;
            await TestIfHalal();
            await Task.Delay(5000);
            ProgressTextBox.Text = "Package OK...";
            ProgressTextBox.Text = "Installing the app certificate...";
            InstallationProgressBar.Value = 20;
            await InstallCertificate();
            ProgressTextBox.Text = "Installing the FluentPad package...";
            InstallationProgressBar.Value = 50;
            await AppAppxMsix();
            await Task.Delay(5000);
            ProgressTextBox.Text = "Installation complete, cleaning and checking";
            InstallationProgressBar.Value = 90;
            await Task.Delay(1000);
            ProgressTextBox.Text = "Installation completed correctly";
            InstallationProgressBar.Value = 100;
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).pagesframe.Navigate(new Uri("/Pages/EndPage.xaml", UriKind.Relative));
                    }
                }
            }
        }

        private async Task InstallCertificate()
        {

        }

        private async Task TestIfHalal()
        {

        }

        private async Task AppAppxMsix()
        {

        }

    }
}
