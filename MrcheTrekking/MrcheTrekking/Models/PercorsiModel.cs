using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
