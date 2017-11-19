using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace ReneataFanBot.Services
{
    public class ImageService
    {
        public async Task<string> GetImage()
        {
            string url = "http://sayyes.dtask.idv.tw/api/say";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Method = "GET";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream, Encoding.UTF8);
                    var content = await reader.ReadToEndAsync();

                    var result = JsonConvert.DeserializeObject<ImageData>(content);

                    return result.Url;                  
                }
            }
        }

    }
}