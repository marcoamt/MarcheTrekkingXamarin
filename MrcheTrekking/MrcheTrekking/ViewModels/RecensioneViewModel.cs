using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MrcheTrekking.Models;
using XLabs.Forms.Mvvm;

namespace MrcheTrekking.ViewModels
{
    public class RecensioneViewModel : ViewModel
    {
        private readonly RecensioneModel _recensione;
        public int Id
        {
            get
            {
                return _recensione.IdRecensione;
            }
        }

        public string NomePercorso
        {
            get
            {
                return _recensione.NomePercorso;
            }
        }

        public string Recensione
        {

            get
            {
                return _recensione.Recensione;
            }
        }
        public string UserName
        {

            get
            {
                return _recensione.UserName;
            }
        }


        public RecensioneViewModel(RecensioneModel recensione)
            {
                _recensione = recensione;
            }
    
    }
}
