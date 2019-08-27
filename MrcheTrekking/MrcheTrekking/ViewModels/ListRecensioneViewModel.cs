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
    public class ListRecenzioneViewModel : ViewModel
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
        public ListRecensioneViewModel()
        {
            //ItemSelectedCommand = new Command<PercorsiViewModel>(OnItemSelected);
            Recensioni = new ObservableCollection<RecensioneViewModel>();
            GetRecensione(Recensione);
        }


        public static async Task GetRecensione(IList<RecensioneViewModel> recensione)
        {
            var uri = new Uri("http://marchetrekking.altervista.org/recensioni.php");
            HttpClient myClient = new HttpClient();

            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<RecensioneModel>>(content);
                for (int i = 0; i < Items.Count; i++)
                {
                    recensione.Add(new RecensioneViewModel(Items[i]));
                }
            }



        }



    }
}