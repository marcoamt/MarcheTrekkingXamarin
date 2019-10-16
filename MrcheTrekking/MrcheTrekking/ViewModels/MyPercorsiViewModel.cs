using MrcheTrekking.Models;
using XLabs.Forms.Mvvm;

namespace MrcheTrekking.ViewModels
{
    public class MyPercorsiViewModel: ViewModel
    {
        private readonly MyPercorsiModel _percorso;
        private string p;

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
            get { return string.Format("Livello: {0} \n Lunghezza: {1} \n Durata: {2}", _percorso.Livello, _percorso.Lunghezza, _percorso.Durata); }
        }

        public MyPercorsiViewModel(MyPercorsiModel percorso)
        {
            _percorso = percorso;
        }

        public MyPercorsiViewModel(string p)
        {
            this.p = p;
        }
    }
}
