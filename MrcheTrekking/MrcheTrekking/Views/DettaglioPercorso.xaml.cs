using System;
using System.Collections.Generic;
using MrcheTrekking.Models;
using Xamarin.Forms;

namespace MrcheTrekking.Views
{
    public partial class DettaglioPercorso : ContentPage
    {
        public DettaglioPercorso(Object a)
        {
            InitializeComponent();

            PercorsiModel p = (MrcheTrekking.Models.PercorsiModel)a;

            string nome = p.Nome;
            string desc = p.Descrizione;
            double lunghezza = p.Lunghezza;
            int livello = p.Livello;
            string durata = p.Durata;
            string img = p.Immagine;
            string map = p.Mappa;

            descrizione.Text = "Nome: " + nome +
                                "\nDescrizione: " + desc +
                                "\nLunghezza: " + lunghezza +
                                "\nLivello: " + livello +
                                "\nDurata: " + durata ;


        }
    }
}
