using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using MrcheTrekking.Models;
using Newtonsoft.Json;

namespace MrcheTrekking.Data
{
    public static class DataService
    {

        /*public static Task<List<PercorsiModel>> GetAll()
        {
            return GetPercorsi();
        }

        public static async Task<List<PercorsiModel>> GetPercorsi()
        {
            List<PercorsiModel> Items = new List<PercorsiModel>();
            try
            {
                var uri = new Uri("http://marchetrekking.altervista.org/percorsiJSON.php");
                HttpClient myClient = new HttpClient();

                var response = await myClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<PercorsiModel>>(content);
                    int name = Items.Count;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return Items;
        }*/

    }
}
