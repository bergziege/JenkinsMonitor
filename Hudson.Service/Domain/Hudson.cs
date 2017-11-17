using System.Collections.Generic;

namespace De.BerndNet2000.Hudson.Service.Domain {
    /// <summary>
    ///     Domain Objekt für einen Hudson Server
    /// </summary>
    public class Hudson {
        /// <summary>
        ///     Liefert bzw. setzt die Jobs des Hudson
        /// </summary>
        public List<Job> Jobs { get; set; }
    }
}