using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TP3Allocine2.Model;

namespace TP3Allocine2.Service
{
    class GPSService
    {
        private static GPSService instance = null;

        private string _bingMapsKey = "Ag7KBEIMrvvjF2Kpz9Ze9UaNNoj1jkizmw-_bxWFpRaLJEXzBGNW-IFl4aHj5jd1";

        public string BingMapsKey { 
            get => _bingMapsKey; 
            set => _bingMapsKey = value; 
        }

        public static GPSService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GPSService();
                }
                return instance;
            }
        }

        private HttpClient client = new HttpClient();

        public async Task<HttpContent> getLocation(Compte compte)
        {
            client = new HttpClient();
            string url = $"http://dev.virtualearth.net/REST/v1/Locations/FR/{compte.CodePostal}/{compte.Ville}/{compte.Rue}?key={BingMapsKey}";
            HttpResponseMessage response = await client.GetAsync(url);

            dynamic jObj = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            compte.Latitude = jObj.resourceSets[0].resources[0].geocodePoints[0].coordinates[0];
            compte.Longitude = jObj.resourceSets[0].resources[0].geocodePoints[0].coordinates[1];

            return response.Content;
        }
    }
}
