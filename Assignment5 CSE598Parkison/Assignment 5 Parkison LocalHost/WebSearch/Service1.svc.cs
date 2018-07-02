using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebSearch
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private const string Key = "872a963dd4f54481ba1f887dc5b0f8a1";
        private const string Url = "https://api.cognitive.microsoft.com/bing/v7.0/search";

        public string search(string query)
        {
            string[] queryArray = query.Split(' ');
            HashSet<string> set = new HashSet<string>();

            foreach (string queryElement in queryArray)
            {
                //search query
                var uriQuery = Url + "?q=" + query.Trim(); //Uri.EscapeDataString(query);
                //return max of 50 results
                uriQuery += "&count=50";
                //Target webpages
                uriQuery += "&responseFilter=Webpages";
                //create request
                System.Net.WebRequest request = HttpWebRequest.Create(uriQuery);
                //Add key top header
                request.Headers["Ocp-Apim-Subscription-Key"] = Key;
                //get response
                HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
                string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
                RootObject jsonObject = JsonConvert.DeserializeObject<RootObject>(json);
                //exctract service endpoints
                foreach (var val in jsonObject.webPages.value)
                {
                    set.Add(val.url);
                }
            }
            string[] serviceUrls = set.ToArray();
            string jsonArray = JsonConvert.SerializeObject(serviceUrls);
            return jsonArray;
        }

        public class QueryContext
        {
            public string originalQuery { get; set; }
        }

        public class About
        {
            public string name { get; set; }
        }

        public class SearchTag
        {
            public string name { get; set; }
            public string content { get; set; }
        }

        public class Value
        {
            public string id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public bool isFamilyFriendly { get; set; }
            public string displayUrl { get; set; }
            public string snippet { get; set; }
            public DateTime dateLastCrawled { get; set; }
            public string language { get; set; }
            public List<About> about { get; set; }
            public List<SearchTag> searchTags { get; set; }
        }

        public class WebPages
        {
            public string webSearchUrl { get; set; }
            public int totalEstimatedMatches { get; set; }
            public List<Value> value { get; set; }
        }

        public class License
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class ContractualRule
        {
            public string _type { get; set; }
            public string targetPropertyName { get; set; }
            public bool mustBeCloseToContent { get; set; }
            public License license { get; set; }
            public string licenseNotice { get; set; }
            public string text { get; set; }
            public string url { get; set; }
        }

        public class Provider
        {
            public string _type { get; set; }
            public string url { get; set; }
        }

        public class Image
        {
            public string name { get; set; }
            public string thumbnailUrl { get; set; }
            public List<Provider> provider { get; set; }
            public string hostPageUrl { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public int sourceWidth { get; set; }
            public int sourceHeight { get; set; }
        }

        public class EntityPresentationInfo
        {
            public string entityScenario { get; set; }
            public List<string> entityTypeHints { get; set; }
        }

        public class Value2
        {
            public string id { get; set; }
            public List<ContractualRule> contractualRules { get; set; }
            public string webSearchUrl { get; set; }
            public string name { get; set; }
            public Image image { get; set; }
            public string description { get; set; }
            public EntityPresentationInfo entityPresentationInfo { get; set; }
            public string bingId { get; set; }
        }

        public class Entities
        {
            public List<Value2> value { get; set; }
        }

        public class Value3
        {
            public string text { get; set; }
            public string displayText { get; set; }
            public string webSearchUrl { get; set; }
        }

        public class RelatedSearches
        {
            public string id { get; set; }
            public List<Value3> value { get; set; }
        }

        public class Value4
        {
            public string id { get; set; }
        }

        public class Item
        {
            public string answerType { get; set; }
            public int resultIndex { get; set; }
            public Value4 value { get; set; }
        }

        public class Mainline
        {
            public List<Item> items { get; set; }
        }

        public class Value5
        {
            public string id { get; set; }
        }

        public class Item2
        {
            public string answerType { get; set; }
            public int resultIndex { get; set; }
            public Value5 value { get; set; }
        }

        public class Sidebar
        {
            public List<Item2> items { get; set; }
        }

        public class RankingResponse
        {
            public Mainline mainline { get; set; }
            public Sidebar sidebar { get; set; }
        }

        public class RootObject
        {
            public string _type { get; set; }
            public QueryContext queryContext { get; set; }
            public WebPages webPages { get; set; }
            public Entities entities { get; set; }
            public RelatedSearches relatedSearches { get; set; }
            public RankingResponse rankingResponse { get; set; }
        }
    }
}

