using System.Windows;

using De.BerndNet2000.PersonalStatusMonitor.Ui.Windows;

namespace De.BerndNet2000.PersonalStatusMonitor {
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            MainWindow main = new MainWindow();
            MainWindow = main;
            MainWindow.Show();
        }

        
    }
}
