using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Net;

namespace TwitterSearcher
{
    public class Searcher
    {
        private string _baseSearchUrl;
        private static XNamespace _namespace = "http://www.w3.org/2005/Atom";

        public Searcher(string baseUrl)
        {
            _baseSearchUrl = baseUrl;
        }

        public void Search(string query, Action<IEnumerable<Tweet>> callback)
        {
            var searchClient = new WebClient();

            searchClient.DownloadStringCompleted += (sender, e) => 
            {
                IEnumerable<Tweet> results =
                    XElement.Parse(e.Result)
                        .Descendants(_namespace + "entry")
                        .Select(entry => new Tweet()
                        {
                            Title = (string)entry.Element(_namespace + "title"),
                            Published = DateTime.Parse((string)entry.Element(_namespace + "published")),
                            Author = (string)entry
                                                .Descendants(_namespace + "author")
                                                .First()
                                                .Element(_namespace + "name")
                        });

                callback(results);
            };
            searchClient.DownloadStringAsync(new Uri(_baseSearchUrl + Uri.EscapeDataString(query)));
        }
    }
}
