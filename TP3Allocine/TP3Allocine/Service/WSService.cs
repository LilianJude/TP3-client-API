using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TP3Allocine.Model;

namespace TP3Allocine.Service
{
    class WSService
    {
        private static WSService instance = null;

        private static HttpClient client = new HttpClient();

        public WSService()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:5000/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static WSService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WSService();
                }
                return instance;
            }
        }

        static async Task<Compte> GetCompteByEmailAsync(string email)
        {
            Compte compte = null;
            HttpResponseMessage response = await client.GetAsync(String.Concat("Compte/GetCompteByEmail/", email));
            if (response.IsSuccessStatusCode)
            {
                compte = await response.Content.ReadAsAsync<Compte>();
            }
            return compte;
        }
    }
}
