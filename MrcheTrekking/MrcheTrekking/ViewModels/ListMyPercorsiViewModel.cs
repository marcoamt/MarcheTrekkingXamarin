using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MrcheTrekking.Models;
using System.Net.Http;
using XLabs.Forms.Mvvm;
using Newtonsoft.Json;



namespace MrcheTrekking.ViewModels
{
    class ListMyPercorsiViewModel : ViewModel
    {
        private IList<PercorsiViewModel> _percorsi;
        private IList<string> _nomi;

        public IList<PercorsiViewModel> Percorsi
        {
            get
            {
                return _percorsi;
            }
            set
            {
                _percorsi = value;
                NotifyPropertyChanged();
            }
        }

        public IList<string> Nomi
        {
            get
            {
                return _nomi;
            }
            set
            {
                _nomi = value;
                NotifyPropertyChanged();
            }
        }

        public ListMyPercorsiViewModel()
        {
            //ItemSelectedCommand = new Command<PercorsiViewModel>(OnItemSelected);
            Percorsi = new ObservableCollection<PercorsiViewModel>();
            Nomi = new ObservableCollection<string>();
            GetPercorsi(Percorsi, Nomi);
        }

        public static async Task GetPercorsi(IList<PercorsiViewModel> percorsi, IList<String> nomi)
        {
            var uri = new Uri("http://marchetrekking.altervista.org/myPercorsiJSON.php");

            //body della post request
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string> ("username",Utility.Settings.User),
            });

            HttpClient myClient = new HttpClient();

            var response = await myClient.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                var risp = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<PercorsiModel>>(risp);
                for (int i = 0; i < Items.Count; i++)
                {
                    percorsi.Add(new PercorsiViewModel(Items[i]));
                    nomi.Add(Items[i].Nome);
                }
            }



        }
    }
}
