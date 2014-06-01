using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        /// <summary>
        /// The string response from the server.
        /// </summary>
        private string response;
        /// <summary>
        /// Client which handles all async server requests.
        /// </summary>
        private HttpClient getClient;

        /// <summary>
        /// Constructs a new ApacheMapList with provided URI.
        /// </summary>
        /// <param name="endpoint">The URI to the Apache directory listing.</param>
        public ApacheMapList(Uri endpoint)
        {
            this.endpoint = endpoint;
            getClient = new HttpClient();
        }

        /// <summary>
        /// Constructs a new ApacheMapList with provided URI as string.
        /// </summary>
        /// <param name="endpoint">The (string) URI to the Apache directory listing.</param>
        public ApacheMapList(String endpoint) : this(new Uri(endpoint)) { }

        /// <summary>
        /// Starts an async GET on the current endpoint.
        /// </summary>
        public async void get()
        {
            // UI progress bar update before call
            using (getClient)
            {
                // Return response from server
                var responseStream = await getClient.GetAsync(endpoint);
                // Interpret resultant stream as string, now we can do something with it!
                response = await responseStream.Content.ReadAsStringAsync();
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
