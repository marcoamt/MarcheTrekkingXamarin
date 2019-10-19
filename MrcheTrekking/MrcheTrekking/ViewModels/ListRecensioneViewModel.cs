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
            _ = Data.GetRecensione(Items =>
            {
                foreach (RecensioneViewModel item in Items)
                {
                    Recensioni.Add(item);
                }
            }, nomePercorso);
        }





    }
}