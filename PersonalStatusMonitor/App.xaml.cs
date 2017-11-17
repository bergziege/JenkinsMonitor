using System.Windows;

using De.BerndNet2000.Hudson.Service;
using De.BerndNet2000.PersonalStatusMonitor.Service;
using De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage;
using De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage.ViewModels;
using De.BerndNet2000.PersonalStatusMonitor.Ui.Windows;
using De.BerndNet2000.PersonalStatusMonitor.Ui.Windows.ViewModels;

using Unity;

namespace De.BerndNet2000.PersonalStatusMonitor {
    /// <summary>
    ///     Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            IUnityContainer container = SetupContainer();

            MainView main = container.Resolve<MainView>();
            IMainViewModel vm = container.Resolve<IMainViewModel>();
            main.DataContext = vm;
            MainWindow = main;
            MainWindow.Show();
        }

        private IUnityContainer SetupContainer() {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<StripeConnector>();
            container.RegisterType<HudsonService>();

            container.RegisterType<IMainViewModel, MainViewModel>();
            container.RegisterType<ILoginViewModel, LoginViewModel>();

            container.RegisterType<MainView>();

            return container;
        }
    }
}