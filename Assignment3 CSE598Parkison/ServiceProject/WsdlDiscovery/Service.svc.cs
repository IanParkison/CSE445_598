using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace WsdlDiscovery
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService
    {
        //Service key from microsoft and url endpoint
        private const string Key = "872a963dd4f54481ba1f887dc5b0f8a1";
        private const string Url = "https://api.cognitive.microsoft.com/bing/v7.0/search";        

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

        public string[] WsdlDiscovery(string keyWords)
        {
            string[] queryArray = keyWords.Split(' ');
            HashSet<string> set = new HashSet<string>();

            foreach (string query in queryArray)
            {              
                //search query
                var uriQuery = Url + "?q=" + query.Trim(); //Uri.EscapeDataString(query);
                //return max of 100 results
                uriQuery += "&count=100";
                //Target webpages
                uriQuery += "&responseFilter=Webpages";
                //create request
                WebRequest request = HttpWebRequest.Create(uriQuery);
                //Add key top header
                request.Headers["Ocp-Apim-Subscription-Key"] = Key;
                //get response
                HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
                string json = new StreamReader(response.GetResponseStream()).ReadToEnd();
                RootObject jsonObject = JsonConvert.DeserializeObject<RootObject>(json);              
                //exctract service endpoints
                foreach (var val in jsonObject.webPages.value)
                {
                    if (val.url.StartsWith("http") && (val.url.EndsWith(".wsdl") || val.url.EndsWith(".php?wsdl") ||
                        val.url.EndsWith(".svc?wsdl") || val.url.EndsWith(".asmx?wsdl")))
                    {
                        set.Add(val.url);
                    }
                }
            }
            string[] serviceUrls = set.ToArray();
            return serviceUrls;
        }

        public string[] Top10Words(string url)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            WebToStringService.ServiceClient proxy = new WebToStringService.ServiceClient();
            string rawWebText;
            try
            {
                //get webpage as text
                rawWebText = proxy.GetWebContent(url);
            }
            catch (Exception e)
            {
                string[] exceptionArray = { "There was an error with this url" };
                return exceptionArray;
            }
            //scrape tags from html doc
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(rawWebText);
            var pageText = htmlDoc.DocumentNode.InnerText;
            List<string> list = new List<string>();
            //read document line by line and store words as elements
            using (StringReader reader = new StringReader(pageText))
            {
                string line, newLine;
                while((line = reader.ReadLine()) != null)
                {                    
                    newLine = Regex.Replace(line, @"[\p{P}\^\=\d]-[-]", "");
                    string[] temp;
                    temp = newLine.Split(' ');
                    foreach (string element in temp)
                    {
                        if (element.Length > 2 && element.Length < 46)
                        {
                            list.Add(element.ToLower().Trim());                          
                        }
                    }                    
                }
            }
            //add elements to dictionary
            foreach (string element in list)
            {
                if (!String.IsNullOrEmpty(element))
                {                
                    if (dictionary.ContainsKey(element))
                    {
                        dictionary[element.Trim()] = dictionary[element] + 1;
                    }
                    else
                    {
                        dictionary[element] = 1;
                    }
                }
            }
            //sort dictionary
            var sortedDict = (dictionary.OrderByDescending(entry => entry.Value)
                     .Take(10)
                     .ToDictionary(pair => pair.Key, pair => pair.Value));
            //build final array of top 10 words
            string[] result = new string[10];
            int index = 0;
            foreach (KeyValuePair<string, int> entry in sortedDict)
            {
                result[index] = entry.Key + " " + entry.Value.ToString();
                index++;
            }
            return result;
        }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
        if (composite == null)
        {
            throw new ArgumentNullException("composite");
        }
        if (composite.BoolValue)
        {
            composite.StringValue += "Suffix";
        }
            return composite;
        }
    }
}    
