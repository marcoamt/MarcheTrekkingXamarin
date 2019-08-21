using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MrcheTrekking.Models;
using Newtonsoft.Json;

namespace MrcheTrekking.Data
{
    public static class DataService
    {
        /*public static async Task<List<Percorsi>> GetAll()
        {
            var uri = "http://marchetrekking.altervista.org/percorsi.php";

            //inoltro richiesta al server
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(uri);

            var risp = await response.Content.ReadAsStringAsync();  //risposta del server
            List<Percorsi> Items = JsonConvert.DeserializeObject<List<Percorsi>>(risp);

            return Items;

        }*/
            
        
    }
}
