using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MrcheTrekking.Models;
using XLabs.Forms.Mvvm;

namespace MrcheTrekking.ViewModels
{
    public class percorsiViewModel : ViewModel
    {
        ObservableCollection<Percorsi> PercorsiList { get; set; }

        public percorsiViewModel()
        {
            PercorsiList = new ObservableCollection<Percorsi>
            {
                new Percorsi
                {
                    Nome = "Baboon",
                    Descrizione = "Africa & Asia",
                    Livello = 2,
                    Lunghezza = 200,
                    Durata = "3",
                    Immagine = "img",
                    Mappa = "",

                },
                new Percorsi
                {
                    Nome = "cvjb",
                    Descrizione = "fsdg",
                    Livello = 2,
                    Lunghezza = 200,
                    Durata = "3",
                    Immagine = "img",
                    Mappa = "",

                }
            };
        }
    }
}
