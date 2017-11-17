using De.BerndNet2000.Hudson.Service.Helper;

namespace De.BerndNet2000.Hudson.Service.Domain {
    /// <summary>
    ///     Ein Job im Hudson
    /// </summary>
    public class Job {
        /// <summary>
        ///     LIefert bzw. setzt die Hudson Farbe des Jobs
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        ///     LIefert die Hudson Farbe als <see cref="JobStatus" />
        /// </summary>
        public JobStatus JobStatus {
            get { return JobStatusConverter.JobColorToStatus(Color); }
        }

        /// <summary>
        ///     Liefert bzw. setzt den Namen des Jobs.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     LIefert bzw. setzt die URL des Jobs
        /// </summary>
        public string Url { get; set; }
    }
}