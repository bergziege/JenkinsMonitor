using System.Windows;
using System.Windows.Controls;

using De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage.ViewModels;

namespace De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage {
    /// <summary>
    ///     Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : UserControl {
        public Login() {
            InitializeComponent();
            Loaded += Login_Loaded;
        }

        private void Login_Loaded(object sender, RoutedEventArgs e) {
            if (DataContext == null) {
                DataContext = new LoginViewModel();
            }
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e) {
            if (DataContext is ILoginViewModel) {
                ((ILoginViewModel)DataContext).Password = _pwdBox.Password;
            }
        }
    }
}