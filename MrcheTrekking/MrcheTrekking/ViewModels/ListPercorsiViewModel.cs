using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;
using System.Threading.Tasks;
using MrcheTrekking.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System;

namespace MrcheTrekking.ViewModels
{
    public class ListPercorsiViewModel : ViewModel
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

        public ListPercorsiViewModel()
        {
            Percorsi = new ObservableCollection<PercorsiViewModel>();
            Nomi = new ObservableCollection<string>();
            GetPercorsi(Percorsi, Nomi);
        }


        public static async Task GetPercorsi(IList<PercorsiViewModel> percorsi, IList<String> nomi)
        {
            //ottengo la lista di tutti i percorsi che mi serviranno per popolare la listview di Percorsi
            //e ottengo una lista di solo i nomi dei percorsi che uso nella select per lasciare recensioni
            var uri = new Uri("http://marchetrekking.altervista.org/percorsiJSON.php");
            HttpClient myClient = new HttpClient();

            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<PercorsiModel>>(content);
                for(int i = 0; i < Items.Count; i++)
                {
                    var p = new PercorsiViewModel(Items[i]);
                    percorsi.Add(p);
                    nomi.Add(Items[i].Nome);
                }
            }

            

        }



    }
}

