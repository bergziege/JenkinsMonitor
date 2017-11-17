using System.Collections.ObjectModel;
using System.Windows.Media;

using FirstFloor.ModernUI.Presentation;

using ReactiveUI;

namespace De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage.ViewModels {
    public class LoginDesignViewModel:ReactiveObject, ILoginViewModel {
        private RelayCommand _loginCommand;
        private ObservableCollection<IJobViewModel> _jobs;
        private string _server;
        private string _username;
        private string _password;
        private string _rotationOffset;
        private Color _bottomColor;
        private Color _leftColor;
        private Color _rightColor;
        private Color _topColor;
        public RelayCommand LoginCommand {
            get { return _loginCommand; }
        }

        public ObservableCollection<IJobViewModel> Jobs {
            get { return new ObservableCollection<IJobViewModel>(){new JobDesignViewModel(){Selected = true}, new JobDesignViewModel(), new JobDesignViewModel(){Selected = true}}; }
        }

        public string Server {
            get { return "server"; }
            set { _server = value; }
        }

        public string Username {
            get { return "user"; }
            set { _username = value; }
        }

        public string Password {
            get { return "pwd"; }
            set { _password = value; }
        }

        public string RotationOffset {
            get { return "2"; }
            set { _rotationOffset = value; }
        }

        public Color BottomColor {
            get { return Colors.Lime; }
            set { _bottomColor = value; }
        }

        public Color LeftColor {
            get { return Colors.Red; }
            set { _leftColor = value; }
        }

        public Color RightColor {
            get { return Colors.Blue; }
            set { _rightColor = value; }
        }

        public Color TopColor {
            get { return Colors.Yellow; }
            set { _topColor = value; }
        }
    }
}