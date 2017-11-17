using System.Collections.ObjectModel;
using System.Windows.Media;

using FirstFloor.ModernUI.Presentation;

namespace De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage {
    public interface ILoginViewModel {
        RelayCommand LoginCommand { get; }
        ObservableCollection<IJobViewModel> Jobs { get; }
        string Server { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string RotationOffset { get; set; }

        Color BottomColor { get; set; }
        Color LeftColor { get; set; }
        Color RightColor { get; set; }
        Color TopColor { get; set; }
    }
}