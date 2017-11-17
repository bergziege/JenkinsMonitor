using De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage;

namespace De.BerndNet2000.PersonalStatusMonitor.Ui.Windows.ViewModels {
    public class MainViewModel : IMainViewModel {
        /// <summary>Initialisiert eine neue Instanz der <see cref="T:System.Object" />-Klasse.</summary>
        public MainViewModel(ILoginViewModel loginViewModel) {
            LoginViewModel = loginViewModel;
        }

        public ILoginViewModel LoginViewModel { get; }
    }
}