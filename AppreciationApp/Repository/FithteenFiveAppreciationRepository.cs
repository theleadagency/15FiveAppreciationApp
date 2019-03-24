using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AppreciationApp.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AppreciationApp.Repository
{
    public class FifteenFiveAppreciationRepository : IFifteenFiveAppreciationRepository
    {
        public List<HighFives> GetWeeklyHighFives()
        {
            var APIKey = ""; //API Key Goes Here. Don't add it to the repo
            var url = @"https://theleadagency.15five.com/api/public/high-five/";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", APIKey);
            
            UriBuilder builder = new UriBuilder(url);
            builder.Query = "created_on_start=" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            var response = client.GetAsync(builder.Uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseResults = response.Content.ReadAsStringAsync().Result;
                dynamic result = JsonConvert.DeserializeObject(responseResults);
                //TODo : Make a service and move this into the service
                var highFives = new List<HighFives>();
                foreach (var highFive in result.results)
                {
                    highFives.Add(new HighFives()
                    {
                     Message   = highFive.text
                    });
                }
                return highFives;
            }

            throw new Exception("Request to 15Five was unsuccessful");
        }
    }

}
