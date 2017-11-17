using De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage;
using De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage.DesignViewModels;
using De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage.ViewModels;

namespace De.BerndNet2000.PersonalStatusMonitor.Ui.Windows.DesignViewModels {
    public class MainDesignViewModel : IMainViewModel {
        public ILoginViewModel LoginViewModel { get; } = new LoginDesignViewModel();
    }
}