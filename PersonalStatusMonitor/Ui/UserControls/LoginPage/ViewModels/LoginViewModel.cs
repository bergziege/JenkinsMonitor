using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;

using De.BerndNet2000.Hudson.Service;
using De.BerndNet2000.Hudson.Service.Domain;
using De.BerndNet2000.PersonalStatusMonitor.Domain;
using De.BerndNet2000.PersonalStatusMonitor.Service;

using FirstFloor.ModernUI.Presentation;

using ReactiveUI;

namespace De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage.ViewModels {
    public class LoginViewModel : ReactiveObject, ILoginViewModel {
        private readonly ObservableCollection<IJobViewModel> _jobs = new ObservableCollection<IJobViewModel>();
        private readonly StripeService _stripe;
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private Color _bottomColor;

        private RelayCommand _getJobsCommand;
        private Color _leftColor;
        private string _password;
        private Color _rightColor;
        private string _rotationOffset;
        private string _server;
        private Color _topColor;
        private string _username = Environment.UserName;

        public LoginViewModel() {
            _stripe = new StripeService("COM3");
            _stripe.PropertyChanged += StripePropertyChanged;
            Server = "";
        }

        public Color BottomColor {
            get { return _bottomColor; }
            set {
                this.RaiseAndSetIfChanged(ref _bottomColor, value);
                _stripe.SendColor(StripeQuadrant.Bottom, value);
            }
        }
        public ObservableCollection<IJobViewModel> Jobs {
            get { return _jobs; }
        }

        public Color LeftColor {
            get { return _leftColor; }
            set {
                this.RaiseAndSetIfChanged(ref _leftColor, value);
                _stripe.SendColor(StripeQuadrant.Left, value);
            }
        }
        /// <summary>
        /// </summary>
        public RelayCommand LoginCommand {
            get {
                if (_getJobsCommand == null) {
                    _getJobsCommand = new RelayCommand(Login);
                }

                return _getJobsCommand;
            }
        }
        public string Password {
            get { return _password; }
            set { this.RaiseAndSetIfChanged(ref _password, value); }
        }

        public Color RightColor {
            get { return _rightColor; }
            set {
                this.RaiseAndSetIfChanged(ref _rightColor, value);
                _stripe.SendColor(StripeQuadrant.Right, value);
            }
        }
        public string RotationOffset {
            get { return _rotationOffset; }
            set { this.RaiseAndSetIfChanged(ref _rotationOffset, value); }
        }

        public string Server {
            get { return _server; }
            set { this.RaiseAndSetIfChanged(ref _server, value); }
        }
        public Color TopColor {
            get { return _topColor; }
            set {
                this.RaiseAndSetIfChanged(ref _topColor, value);
                _stripe.SendColor(StripeQuadrant.Top, value);
            }
        }

        public string Username {
            get { return _username; }
            set { this.RaiseAndSetIfChanged(ref _username, value); }
        }

        private void GetJobs() {
            HudsonService hudson = new HudsonService();

            IList<Job> jobs = hudson.GetAllJobs(Server, Username, Password);

            IList<IJobViewModel> oldJobs =
                    _jobs.Where(jobViewModel => jobs.All(x => x.Name != jobViewModel.Name)).ToList();

            foreach (IJobViewModel jobViewModel in oldJobs) {
                jobViewModel.PropertyChanged -= JobVmPropertyChanged;
                _jobs.Remove(jobViewModel);
            }

            foreach (Job job in jobs) {
                if (_jobs.All(x => x.Name != job.Name)) {
                    IJobViewModel jobVm = new JobViewModel(job);
                    jobVm.PropertyChanged += JobVmPropertyChanged;
                    _jobs.Add(jobVm);
                } else {
                    foreach (IJobViewModel jobVm in _jobs.Where(x => x.Name == job.Name)) {
                        jobVm.JobStatus = job.JobStatus;
                    }
                }
            }

            SetColors();
        }

        private void JobVmPropertyChanged(object sender, PropertyChangedEventArgs e) {
            SetColors();
        }

        private void Login(object obj) {
            _timer.Interval = TimeSpan.FromSeconds(10);
            _timer.Tick += TimerTick;
            _timer.Start();
            GetJobs();
        }

        private void SetColors() {
            IList<IJobViewModel> selectedJobs = _jobs.Where(x => x.Selected).ToList();

            bool hasGreen = selectedJobs.Any(x => x.JobStatus == JobStatus.Blue);
            bool hasRed = selectedJobs.Any(x => x.JobStatus == JobStatus.Red);
            bool hasYellow = selectedJobs.Any(x => x.JobStatus == JobStatus.Yellow);

            if (selectedJobs.Count == 0) {
                BottomColor = Colors.Black;
                LeftColor = Colors.Black;
                RightColor = Colors.Black;
            }
            TopColor = Colors.Black;

            if (hasRed && !hasGreen) {
                LeftColor = Color.FromRgb(255, 0, 0);
                BottomColor = Color.FromRgb(255, 0, 0);
                RightColor = Color.FromRgb(255, 0, 0);
            }
            if (!hasRed && hasGreen) {
                LeftColor = Color.FromRgb(0, 111, 0);
                BottomColor = Color.FromRgb(0, 111, 0);
                RightColor = Color.FromRgb(0, 111, 0);
            }
            if (hasRed && hasGreen) {
                LeftColor = Color.FromRgb(0, 111, 0);
                BottomColor = Colors.Red;
                RightColor = Color.FromRgb(0, 111, 0);
            }
            if (hasYellow) {
                RightColor = Color.FromRgb(255, 224, 0);
            }
        }

        private void StripePropertyChanged(object sender, PropertyChangedEventArgs e) {
            RotationOffset = _stripe.LastReceived.ToString();
        }

        private void TimerTick(object sender, EventArgs e) {
            GetJobs();
        }
    }
}