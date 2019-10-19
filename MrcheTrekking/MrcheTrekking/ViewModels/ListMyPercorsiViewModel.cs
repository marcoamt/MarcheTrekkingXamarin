using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MrcheTrekking.Models;
using System.Net.Http;
using XLabs.Forms.Mvvm;
using Newtonsoft.Json;
using System.Windows.Input;
using Xamarin.Forms;

namespace MrcheTrekking.ViewModels
{
    class ListMyPercorsiViewModel : ViewModel
    {
        private IList<MyPercorsiViewModel> _percorsi;
        private IList<string> _nomi;

        public IList<MyPercorsiViewModel> Percorsi
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
            Percorsi = new ObservableCollection<MyPercorsiViewModel>();
            _ = Data.GetMyPercorsi(Items =>
            {
                foreach (MyPercorsiViewModel item in Items)
                {
                    Percorsi.Add(item);
                }
            });
        }

    }
}
