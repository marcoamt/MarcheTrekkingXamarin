using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MrcheTrekking.Models
{
    public class PercorsiModel
    {
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public string Mappa { get; set; }
        public double Lunghezza { get; set; }
        public int Livello { get; set; }
        public string Durata { get; set; }
        public string Immagine { get; set; }
        //private int idPercUtente { get; }

        /*public PercorsiModel(PercorsiModel p)
        {
            idPercUtente = p.idPercUtente;
            Nome = p.Nome;
            Descrizione = p.Descrizione;
            Mappa = p.Mappa;
            Lunghezza = p.Lunghezza;
            Livello = p.Livello;
            Durata = p.Durata;
            Immagine = p.Immagine;
        }*/

        public PercorsiModel(string Nome, string Descrizione, string Mappa, double Lunghezza, int Livello, string Durata, string Immagine)
        {
            this.Nome = Nome;
            this.Descrizione = Descrizione;
            this.Mappa = Mappa;
            this.Lunghezza = Lunghezza;
            this.Livello = Livello;
            this.Durata = Durata;
            this.Immagine = Immagine;
        }
    }
}
