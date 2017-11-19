using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ReneataFanBot.Services
{
    public class EmotionDetectService
    {
        public async Task<bool> IsSentencePositive(string sentence)
        {
            string url = $"https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/3014562c-87d7-4241-8131-064936efb241?subscription-key=494dbd60686e471c969ea2736d87679c&verbose=true&timezoneOffset=0&q={HttpUtility.UrlEncode(sentence)}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Method = "GET";

            using (var response = await request.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, Encoding.UTF8);
                    var content = await reader.ReadToEndAsync();

                    var result = JsonConvert.DeserializeObject<CognitiveResponse>(content);
                    var isPositive = result.TopScoringIntent.Intent == "Positive";

                    return isPositive;                    
                }
            }
        }
    }
}