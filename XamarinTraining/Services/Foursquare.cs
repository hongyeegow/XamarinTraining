using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinTraining.Model;

namespace XamarinTraining.Services
{
    public class Foursquare : IFoursquare
    {
        string Base_url = "https://api.foursquare.com/v2/venues/search";
        string ClientID = "S1DG4GQCTS2AB2ASGFQP2NW23U3PNEJGIJQR2VIMTQEYBSDU";
        string ClientSecret = "OKUPIKFXKLPTHNUERWJ45HZJR0L040J5ULKHKLO0QFGGQ2R5";
        public async Task<Place> getvenue(double lat, double lon)
        {
            string ll = $"{lat},{lon}";
            int radius = 250;
            int limit = 10;
            int version = 20200425;

            string url = Base_url + $"?ll={ll}&radius={radius}&limit={limit}&v={version}&client_id={ClientID}&client_secret={ClientSecret}";
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<Place>(result);
                return json;
            }

            return null;
        }
    }
}
