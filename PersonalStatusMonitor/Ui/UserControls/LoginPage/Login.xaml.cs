using System.Windows;
using System.Windows.Controls;

namespace De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage {
    /// <summary>
    ///     Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : UserControl {
        public Login() {
            InitializeComponent();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e) {
            if (DataContext is ILoginViewModel) {
                ((ILoginViewModel)DataContext).Password = _pwdBox.Password;
            }
        }
    }
}