using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using MrcheTrekking.ViewModels;
using Newtonsoft.Json;

namespace MrcheTrekking.Models
{
    public class Data
    {
        public static async Task GetPercorsi(Action<IEnumerable<PercorsiViewModel>> action )
        {
            var uri = new Uri("http://marchetrekking.altervista.org/percorsiJSON.php");
            HttpClient myClient = new HttpClient();
            var percorsi = new ObservableCollection<PercorsiViewModel>();
            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<PercorsiModel>>(content);
                for (int i = 0; i < Items.Count; i++)
                {
                    var p = new PercorsiViewModel(Items[i]);
                    percorsi.Add(p);
                }
                action(percorsi);
            }
        }

        public static async Task GetNomiPercorsi(Action<IEnumerable<string>> action)
        {
            var uri = new Uri("http://marchetrekking.altervista.org/percorsiJSON.php");
            HttpClient myClient = new HttpClient();

            var nomi = new ObservableCollection<string>();

            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<PercorsiModel>>(content);
                for (int i = 0; i < Items.Count; i++)
                {
                    nomi.Add(Items[i].Nome);
                }
                action(nomi);
            }
        }


        public static async Task GetRecensione(Action<IEnumerable<RecensioneViewModel>> action, string percorso)
        {
            var uri = new Uri("http://marchetrekking.altervista.org/recensioniJSON.php");
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string> ("percorso", percorso)
            });
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(uri, content);

            var recensioni = new ObservableCollection<RecensioneViewModel>();

            var risp = await response.Content.ReadAsStringAsync();  //risposta del server
            if (response.IsSuccessStatusCode)
            {
                var Items = JsonConvert.DeserializeObject<List<RecensioneModel>>(risp);
                for (int i = 0; i < Items.Count; i++)
                {
                    recensioni.Add(new RecensioneViewModel(Items[i]));
                }
            }
            action(recensioni);


        }


        public static async Task GetMyPercorsi(Action<IEnumerable<MyPercorsiViewModel>> action)
        {
            var uri = new Uri("http://marchetrekking.altervista.org/myPercorsiJSON.php");

            //body della post request
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string> ("username",Utility.Settings.User),
            });

            var percorsi = new ObservableCollection<MyPercorsiViewModel>();
            HttpClient myClient = new HttpClient();

            var response = await myClient.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                var risp = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<MyPercorsiModel>>(risp);
                for (int i = 0; i < Items.Count; i++)
                {
                    var p = new MyPercorsiViewModel(Items[i]);
                    p.Immagine = "logo";
                    percorsi.Add(p);
                }
            }
            action(percorsi);
        }
    }
}
