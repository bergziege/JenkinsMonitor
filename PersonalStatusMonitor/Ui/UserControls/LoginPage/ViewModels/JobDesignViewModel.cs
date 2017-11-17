using De.BerndNet2000.Hudson.Service.Domain;
using De.BerndNet2000.PersonalStatusMonitor.Domain;

using ReactiveUI;

namespace De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage.ViewModels {
    public class JobDesignViewModel : ReactiveObject, IJobViewModel {
        public JobStatus JobStatus {
            get { return JobStatus.Red; }
            set { }
        }

        public bool Selected { get; set; }

        public string Name {
            get { return "Ich bin ein job"; }
        }
    }
}