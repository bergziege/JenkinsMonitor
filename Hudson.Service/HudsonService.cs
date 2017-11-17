using System.Collections.Generic;

using De.BerndNet2000.Hudson.Service.Domain;

using RestSharp;
using RestSharp.Deserializers;

namespace De.BerndNet2000.Hudson.Service {
    /// <summary>
    /// Service für Hudsonaufrufe
    /// </summary>
    public class HudsonService {
        /// <summary>
        /// Liefert alle Jobs auf den übergebenen Hudson
        /// </summary>
        /// <param name="server">URL ohne API. Z.B.: https://hudsonmaster.queo.local/ </param>
        /// <param name="user">Nutzername im Hudson</param>
        /// <param name="pwd">Passwort des Hudsonnutzers im Klartext wenn benötigt.</param>
        /// <returns></returns>
        public IList<Job> GetAllJobs(string server, string user, string pwd) {
            var client = new RestClient(server);
            client.Authenticator = new HttpBasicAuthenticator(user, pwd);
            var request = new RestRequest("api/json", Method.GET);
            IRestResponse jsonResult = client.Execute(request);
            JsonDeserializer deserializer = new JsonDeserializer();
            Domain.Hudson hudson = deserializer.Deserialize<Domain.Hudson>(jsonResult);
            return hudson.Jobs;
        }

        
    }
}