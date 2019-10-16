using System.Collections.Generic;
using System.Collections.ObjectModel;
using XLabs.Forms.Mvvm;
using System.Threading.Tasks;
using MrcheTrekking.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System;

namespace MrcheTrekking.ViewModels
{
    public class ListRecensioneViewModel : ViewModel
    {
        private IList<RecensioneViewModel> _recensione;

        public IList<RecensioneViewModel> Recensioni
        {
            get
            {
                return _recensione;
            }
            set
            {
                _recensione = value;
                NotifyPropertyChanged();
            }
        }
        public ListRecensioneViewModel(string nomePercorso)
        {
            Recensioni = new ObservableCollection<RecensioneViewModel>();
            GetRecensione(Recensioni, nomePercorso);
        }


        public static async Task GetRecensione(IList<RecensioneViewModel> recensione, string percorso)
        {
            var uri = new Uri("http://marchetrekking.altervista.org/recensioniJSON.php");
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string> ("percorso", percorso)
            });
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(uri, content);
            var risp = await response.Content.ReadAsStringAsync();  //risposta del server
            if (response.IsSuccessStatusCode)
            {
                var Items = JsonConvert.DeserializeObject<List<RecensioneModel>>(risp);
                for (int i = 0; i < Items.Count; i++)
                {
                    recensione.Add(new RecensioneViewModel(Items[i]));
                }
            }


        }



    }
}