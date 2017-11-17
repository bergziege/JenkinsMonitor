using System.ComponentModel;

using De.BerndNet2000.Hudson.Service.Domain;
using De.BerndNet2000.PersonalStatusMonitor.Domain;

namespace De.BerndNet2000.PersonalStatusMonitor.Ui.UserControls.LoginPage {
    public interface IJobViewModel: INotifyPropertyChanged {
        string Name { get; }
        JobStatus JobStatus { get; set; }
        bool Selected { get; set; }
    }
}