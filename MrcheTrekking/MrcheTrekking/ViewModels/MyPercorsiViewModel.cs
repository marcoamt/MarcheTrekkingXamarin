using MrcheTrekking.Models;
using XLabs.Forms.Mvvm;

namespace MrcheTrekking.ViewModels
{
    public class MyPercorsiViewModel: ViewModel
    {
        private readonly MyPercorsiModel _percorso;

        public int Id
        {
            get { return _percorso.idPercUtente; }
        }

        public string Nome
        {
            get { return _percorso.Nome; }
        }

        public string Descrizione
        {
            get { return _percorso.Descrizione; }
        }

        public string Mappa
        {
            get { return _percorso.Mappa; }
        }

        public string Immagine
        {
            get { return string.Format("{0}.jpg", _percorso.Immagine); }
            set
            {
                if (_percorso.Immagine != value)
                {
                    _percorso.Immagine = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Caratteristiche
        {
            get { return string.Format("Livello difficoltà: {0} \nLunghezza: {1} km \nDurata: {2} ore", _percorso.Livello, _percorso.Lunghezza, _percorso.Durata); }
        }

        public MyPercorsiViewModel(MyPercorsiModel percorso)
        {
            _percorso = percorso;
        }

    }
}
