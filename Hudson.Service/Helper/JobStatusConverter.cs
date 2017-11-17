using De.BerndNet2000.Hudson.Service.Domain;

namespace De.BerndNet2000.Hudson.Service.Helper {
    /// <summary>
    ///     Konverter für Hudson Status zu <see cref="JobStatus" />
    /// </summary>
    public static class JobStatusConverter {
        /// <summary>
        ///     Konvertiert einen Hudson Status zu einem <see cref="JobStatus" />
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
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
                default:
                    return JobStatus.Disabled;
            }
        }
    }
}