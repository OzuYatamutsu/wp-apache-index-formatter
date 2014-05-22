using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace wp_apache_index_formatter
{
    class ApacheMapList : Dictionary<string, string>
    {
        private Uri endpoint;
        private HttpWebRequest getUrl;
        private WebResponse serverReply;
        private Stream responseStream;

        public ApacheMapList(Uri endpoint)
        {
            this.endpoint = endpoint;
            getUrl = (HttpWebRequest)HttpWebRequest.Create(endpoint);
        }

        public ApacheMapList(String endpoint) : this(new Uri(endpoint)) { }

        void getRequestCallback(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            if (request != null)
            {
                WebResponse response = request.EndGetResponse(result);
                responseStream = response.GetResponseStream();
            }
        }

        public void get()
        {
            // Result will be stored in getUrl
            getUrl.BeginGetResponse(getRequestCallback, getUrl);
        }
    }
}
