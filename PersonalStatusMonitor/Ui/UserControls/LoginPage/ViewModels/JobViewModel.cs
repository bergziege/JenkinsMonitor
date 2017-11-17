using De.BerndNet2000.Hudson.Service.Domain;

using ReactiveUI;

namespace De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage.ViewModels {
    public class JobViewModel : ReactiveObject, IJobViewModel {
        private readonly string _name;
        private JobStatus _jobStatus;
        private bool _selected;

        public JobViewModel(Job job) {
            _name = job.Name;
            _jobStatus = job.JobStatus;
        }

        public JobStatus JobStatus {
            get { return _jobStatus; }
            set { this.RaiseAndSetIfChanged(ref _jobStatus, value); }
        }
        public string Name {
            get { return _name; }
        }

        public bool Selected {
            get { return _selected; }
            set { this.RaiseAndSetIfChanged(ref _selected, value); }
        }
    }
}