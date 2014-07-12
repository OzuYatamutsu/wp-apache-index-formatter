using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace wp_apache_index_formatter
{
    /// <summary>
    /// Handles client-server GETs and extracts filename and URIs from an Apache directory listing.
    /// </summary>
    class ApacheMapList
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
        /// The backing Dictionary which stores the filename-URL pairs.
        /// </summary>
        private Dictionary<string, string> apacheIndex;
        /// <summary>
        /// The number of items currently contained in this ApacheMapList.
        /// </summary>
        private int count;

        /// <summary>
        /// Constructs a new ApacheMapList with provided URI.
        /// </summary>
        /// <param name="endpoint">The URI to the Apache directory listing.</param>
        public ApacheMapList(Uri endpoint)
        {
            this.endpoint = endpoint;
            getClient = new HttpClient();
            apacheIndex = new Dictionary<string, string>();
            count = 0;
        }

        /// <summary>
        /// Constructs a new ApacheMapList with provided URI as string.
        /// </summary>
        /// <param name="endpoint">The (string) URI to the Apache directory listing.</param>
        public ApacheMapList(String endpoint) : this(new Uri(endpoint)) { }

        /// <summary>
        /// Starts an async GET on the current endpoint.
        /// </summary>
        public async Task Get()
        {
            // Clean up
            apacheIndex.Clear();
            response = "";
            getClient = new HttpClient();

            // UI progress bar update before call
            using (getClient)
            {
                // Return response from server
                var responseStream = await getClient.GetAsync(endpoint);
                // Interpret resultant stream as string, now we can do something with it!
                response = await responseStream.Content.ReadAsStringAsync();
            }

            PopulateList(response);
        }

        /// <summary>
        /// Populates a list with members of the Apache index page provided by the response.
        /// </summary>
        /// <param name="rawResponse">An input raw response string.</param>
        /// <returns>True if the list has been successfully populated; false otherwise.</returns>
        private bool PopulateList(string rawResponse)
        {
           var docParser = new HtmlAgilityPack.HtmlDocument();
           docParser.LoadHtml(rawResponse);
           if (docParser.DocumentNode.Descendants("address").ToList().Count() == 0)
           {
               // Apache index pages tend to have an <address> tag
               // So we're assuming if there is none, this is not an Apache index page
               
               return false;
           }

           foreach (var item in docParser.DocumentNode.Descendants("a"))
           {
               if (!item.InnerHtml.Equals("Name")
                   && !item.InnerHtml.Equals("Last modified") && !item.InnerHtml.Equals("Size")
                   && !item.InnerHtml.Equals("Description") && !item.InnerHtml.Equals("Parent Directory")
                )
               {
                   apacheIndex.Add(item.InnerText, endpoint.ToString() + "/" + item.GetAttributeValue("href", ""));
                   count++;
               }
           }

           return (apacheIndex.Count > 0) ? true : false;
        }

        /// <summary>
        /// Returns if the current ApacheMapList is empty.
        /// </summary>
        /// <returns>True if the ApacheMapList is empty; false otherwise.</returns>
        public bool IsEmpty()
        {
            return (apacheIndex.Count > 0) ? true : false;
        }

        /// <summary>
        /// Returns a list of string keys from the backing dictionary.
        /// </summary>
        /// <returns>A list of string keys from the backing dictionary.</returns>
        public List<string> GetKeyList()
        {
            return apacheIndex.Keys.ToList();
        }

        /// <summary>
        /// Returns the number of items contained in this ApacheMapList.
        /// </summary>
        /// <returns>The number of items contained in this ApacheMapList.</returns>
        public int Count()
        {
            return count;
        }
    }
}
