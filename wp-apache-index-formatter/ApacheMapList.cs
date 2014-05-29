using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace wp_apache_index_formatter
{
    /// <summary>
    /// A set of key-value pairs of extracted filename and URIs from an Apache directory listing.
    /// </summary>
    class ApacheMapList : Dictionary<string, string>
    {
        
        /// <summary>
        /// The URI of the Apache directory listing.
        /// </summary>
        private Uri endpoint;
        private HttpWebRequest getUrl;
        private WebResponse serverReply;
        private Stream responseStream;

        /// <summary>
        /// Constructs a new ApacheMapList with provided URI.
        /// </summary>
        /// <param name="endpoint">The URI to the Apache directory listing.</param>
        public ApacheMapList(Uri endpoint)
        {
            this.endpoint = endpoint;
            getUrl = (HttpWebRequest)HttpWebRequest.Create(endpoint);
        }

        /// <summary>
        /// Constructs a new ApacheMapList with provided URI as string.
        /// </summary>
        /// <param name="endpoint">The (string) URI to the Apache directory listing.</param>
        public ApacheMapList(String endpoint) : this(new Uri(endpoint)) { }

        /// <summary>
        /// The callback method for the async HTTP GET performed on the endpoint.
        /// </summary>
        /// <param name="result">The result of the current async operation.</param>
        void getRequestCallback(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            if (request != null)
            {
                WebResponse response = request.EndGetResponse(result);
                responseStream = response.GetResponseStream();
            }
        }

        /// <summary>
        /// Starts an async GET on the current endpoint.
        /// </summary>
        public void get()
        {
            // Clear old stream first
            responseStream = null;
            // Result will be stored in getUrl
            getUrl.BeginGetResponse(getRequestCallback, getUrl);
            if (responseStream != null) // Checks if previous async is completed (is there a better way?)
            {
                string test = parseStream(responseStream);
            }
        }

        /// <summary>
        /// Reads the response stream into a string.
        /// </summary>
        /// <param name="stream">An input response stream.</param>
        /// <returns>The raw string output of the response stream.</returns>
        private string parseStream(Stream stream)
        {
            StreamReader reader = new System.IO.StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
