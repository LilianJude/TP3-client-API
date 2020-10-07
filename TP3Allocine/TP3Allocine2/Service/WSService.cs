using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TP3Allocine2.Model;

namespace TP3Allocine2.Service
{
    public class WSService
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

        public async Task<Compte> GetCompteByEmailAsync(string email)
        {
            Compte compte = null;
            string url = String.Concat("Compte/GetCompteByEmail/", email);
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                compte = await response.Content.ReadAsAsync<Compte>();
            }
            return compte;
        }

        public async Task ModifyCompte(Compte compte)
        {
            string url = String.Concat("Compte/PutCompte/", compte.CompteId);
            HttpResponseMessage response = await client.PutAsJsonAsync(url, compte);
        }

        public async Task AddCompte(Compte compte)
        {
            string url = String.Concat("Compte/PostCompte/");
            HttpResponseMessage response = await client.PostAsJsonAsync(url, compte);
        }
    }
}
