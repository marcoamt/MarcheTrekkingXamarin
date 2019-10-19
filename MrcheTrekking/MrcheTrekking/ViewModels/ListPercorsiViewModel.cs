using System.Collections.Generic;
using System.Collections.ObjectModel;
using XLabs.Forms.Mvvm;
using System.Threading.Tasks;
using MrcheTrekking.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System;
using System.Windows.Input;
using Xamarin.Forms;

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

        /*public ICommand ItemSelectedCommand { get; set; }

        private void OnItemSelected(PercorsiViewModel percorsoVM)
        {
            Navigation.PushAsync<DettaglioPercorsoViewModel>((viewmodel, page) =>
            {
                viewmodel.Percorso = percorsoVM;
            });

        }*/

        public ListPercorsiViewModel()
        {

            //ItemSelectedCommand = new Command<PercorsiViewModel>(OnItemSelected);
            Percorsi = new ObservableCollection<PercorsiViewModel>();
            Nomi = new ObservableCollection<string>();


            //ottengo la lista di tutti i percorsi che mi serviranno per popolare la listview di Percorsi
            //e ottengo una lista di solo i nomi dei percorsi che uso nella select per lasciare recensioni

            _ = Data.GetPercorsi(Items =>
               {
                   foreach (PercorsiViewModel item in Items)
                   {
                       Percorsi.Add(item);
                   }
               });

            _ = Data.GetNomiPercorsi(Items =>
            {
                foreach (string item in Items)
                {
                    Nomi.Add(item);
                }
            });
        }

    }
}

