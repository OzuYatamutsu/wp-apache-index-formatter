using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace wp_apache_index_formatter
{
    class ApacheMapList<string, string> : Dictionary<string, string>
    {
        private Uri endpoint;
        private HttpWebRequest getUrl;
        private Stream getStream;

        public ApacheMapList(Uri endpoint)
        {
            this.endpoint = endpoint;
            getUrl = (HttpWebRequest) HttpWebRequest.Create(endpoint);
            if (!validateEndpoint())
            {
                // Throw something?
            }
        }

        private bool validateEndpoint()
        {
            bool isValid = false;
            return isValid;
        }
    }
}
