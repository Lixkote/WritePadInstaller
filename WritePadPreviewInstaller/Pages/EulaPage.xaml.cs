using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static WritePadPreviewInstaller.asseth;
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
    public sealed partial class EulaPage : Page
    {
        public EulaPage()
        {
            InitializeComponent();
            LoadEula();
        }

        private void LoadEula()
        {
            var bytes = Encoding.Unicode.GetBytes(asseth.eulatext);
            var stream = new MemoryStream(bytes);
            eulabox.Selection.Load(stream, DataFormats.Rtf);
        }

        private void CancelEulaPage_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to cancel installation?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void InstallEulaPage_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).pagesframe.Navigate(new Uri("/Pages/InstallationPage.xaml", UriKind.Relative));
                }
            }
        }

        private void BackEulaPage_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).pagesframe.Navigate(new Uri("/Pages/StartPage.xaml", UriKind.Relative));
                }
            }
        }
    }
}
