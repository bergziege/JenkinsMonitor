using De.BerndNet2000.Hudson.Service.Domain;

using ReactiveUI;

namespace De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage.DesignViewModels {
    public class JobDesignViewModel : ReactiveObject, IJobViewModel {
        public JobStatus JobStatus {
            get { return JobStatus.Red; }
            set { }
        }

        public string Name {
            get { return "Ich bin ein job"; }
        }

        public bool Selected { get; set; }
    }
}