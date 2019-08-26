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
        private IList<String> _nomi;

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

        public IList<String> Nomi
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

        public ICommand ItemSelectedCommand { get; set; }

        private void OnItemSelected(PercorsiViewModel percorsoVM)
        {
            Navigation.PushAsync<DettaglioPercorsoViewModel>((viewmodel, page) =>
            {
                viewmodel.Percorso = percorsoVM;
            });

        }

        public ListPercorsiViewModel()
        {
            ItemSelectedCommand = new Command<PercorsiViewModel>(OnItemSelected);
            Percorsi = new ObservableCollection<PercorsiViewModel>();
             Nomi = new ObservableCollection<String>();
            GetPercorsi(Percorsi, Nomi);
        }


        public static async Task GetPercorsi(IList<PercorsiViewModel> percorsi, IList<String> nomi)
        {
            var uri = new Uri("http://marchetrekking.altervista.org/percorsiJSON.php");
            HttpClient myClient = new HttpClient();

            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<PercorsiModel>>(content);
                for(int i = 0; i < Items.Count; i++)
                {
                    percorsi.Add(new PercorsiViewModel(Items[i]));
                    nomi.Add(Items[i].Nome);
                }
            }

            

        }



    }
}

