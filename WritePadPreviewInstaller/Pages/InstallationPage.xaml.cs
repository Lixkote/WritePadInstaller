using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Windows;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static Windows.Management.Deployment.PackageManager;
using Microsoft.CSharp.RuntimeBinder;
using System.Windows.Documents;
using System.Windows.Input; 
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography.X509Certificates;
using Windows.Management.Deployment;

namespace WritePadPreviewInstaller.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy StartPage.xaml
    /// </summary>
    public sealed partial class InstallationPage : Page
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
            await AppAppxMsix();
            await Task.Delay(1000);
        }

        private async Task InstallCertificate()
        {
            string exePath = Environment.CurrentDirectory;
            string cerFileName = System.IO.Path.Combine(exePath, "AppPackages", "wordpadcert.cer");
            if (File.Exists(cerFileName))
            {
                X509Certificate2Collection collection = new X509Certificate2Collection();
                collection.Import(cerFileName, "", X509KeyStorageFlags.PersistKeySet);
                foreach (X509Certificate2 cert in collection)
                {
                    //inspect cert properties and decide which store to add it to
                    var store = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine);
                    store.Open(OpenFlags.ReadWrite);
                    store.Add(cert);
                    store.Close();
                }

            }
            else
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).pagesframe.Navigate(new Uri("/Pages/ErrorPage.xaml", UriKind.Relative));
                    }
                }
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).setupmainwindow.Title = "Setup Warning: Could not install certificate file.";
                    }
                }
            }
            ProgressTextBox.Text = "Installing the FluentPad package...";
            InstallationProgressBar.Value = 50;
        }

        private async Task TestIfHalal()
        {

        }

        private async Task AppAppxMsix()
        {
            // Create a PackageManager object
            var packageManager = new PackageManager();

            // Specify the path of the msixbundle file
            var exePath = Environment.CurrentDirectory;
            var packageUri = new Uri(System.IO.Path.Combine(exePath, "AppPackages", "wordpadapp.msixbundle"));
            var packageUriSE = System.IO.Path.Combine(exePath, "AppPackages", "wordpadapp.msixbundle");



            if (File.Exists(packageUriSE))
            {
                // Install the package asynchronously
                var deploymentResult = await packageManager.AddPackageAsync(packageUri, null, DeploymentOptions.None);
                if (deploymentResult.IsRegistered)
                {
                    ProgressTextBox.Text = "Installation complete, cleaning and checking";
                    InstallationProgressBar.Value = 90;
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
                else
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).pagesframe.Navigate(new Uri("/Pages/ErrorPage.xaml", UriKind.Relative));
                        }
                    }
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).setupmainwindow.Title = "Setup Warning: FluentPad package could not be installed.";
                        }
                    }
                }
            }
            else
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).setupmainwindow.Title = "Setup Warning: FluentPad package could not be found.";
                    }
                }
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).pagesframe.Navigate(new Uri("/Pages/ErrorPage.xaml", UriKind.Relative));
                    }
                }
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).pagesframe.Navigate(new Uri("/Pages/ErrorPage.xaml", UriKind.Relative));
                    }
                }
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).pagesframe.Navigate(new Uri("/Pages/ErrorPage.xaml", UriKind.Relative));
                    }
                }
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).pagesframe.Navigate(new Uri("/Pages/ErrorPage.xaml", UriKind.Relative));
                    }
                }
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).pagesframe.Navigate(new Uri("/Pages/ErrorPage.xaml", UriKind.Relative));
                    }
                }


            }
        }

    }
}
