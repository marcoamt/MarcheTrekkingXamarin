using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MrcheTrekking.Models;
using XLabs.Forms.Mvvm;

namespace MrcheTrekking.ViewModels
{
    public class PercorsiViewModel : ViewModel
    {
        private readonly PercorsiModel _percorso;

        public string Nome
        {
            get { return _percorso.Nome; }
        }

        public string Descrizione
        {
            get { return _percorso.Descrizione; }
        }

        public string Immagine
        {
            get { return string.Format("{0}.jpg", _percorso.Immagine); }
        }

        public string Caratteristiche
        {
            get { return string.Format("Livello: {0} \n Lunghezza: {1} \n Durata: {2}", _percorso.Livello, _percorso.Lunghezza, _percorso.Durata); }
        }

        public PercorsiViewModel(PercorsiModel percorso)
        {
            _percorso = percorso;
        }
    }
}
