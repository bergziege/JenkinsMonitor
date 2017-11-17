using De.BerndNet2000.Hudson.Service.Domain;
using De.BerndNet2000.PersonalStatusMonitor.Domain;

namespace De.BerndNet2000.PersonalStatusMonitor.Helper {
    public static class JobStatusConverter {
        public static JobStatus JobColorToStatus(string color) {
            switch (color) {
                case "blue":
                    return JobStatus.Blue;
                case "yellow":
                    return JobStatus.Yellow;
                case "red":
                    return JobStatus.Red;
                case "grey":
                    return JobStatus.Grey;
                case "disabled":
                    return JobStatus.Disabled;
                default: return JobStatus.Disabled;
            }
        }
    }
}