﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace MrcheTrekking.Views
{
    public partial class ContinuaAggPercorso : ContentPage
    {
        private string mappa;
        public ContinuaAggPercorso(List<string> latitudine, List<string> longitudine)
        {
            InitializeComponent();
            for (int i = 0; i < latitudine.Count-1; i++)
                mappa += latitudine[i] + ", " + longitudine[i] +",";

            mappa += latitudine[latitudine.Count-1] + ", " + longitudine[longitudine.Count-1];
        }

        //async
        protected async void aggiungi(object sender, EventArgs args)
        {

            string n = nome.Text;
            string nomeClean = n.Replace("'", "''");
            string d = descrizione.Text;
            string descClean = d.Replace("'", "''");
            string lu = lunghezza.Text;
            string l = livello.Text;
            string du = durata.Text;

            if(!string.IsNullOrEmpty(n) && !string.IsNullOrEmpty(d) && !string.IsNullOrEmpty(lu) && !string.IsNullOrEmpty(l) && !string.IsNullOrEmpty(du) )
            {
                if(int.Parse(l) < 6 && int.Parse(l) > 0)
                {
                    var uri = "http://marchetrekking.altervista.org/aggiungi_percorso.php";

                    //body della post request
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string,string> ("nome", nomeClean),
                        new KeyValuePair<string,string> ("desc", descClean),
                        new KeyValuePair<string,string> ("map", mappa),
                        new KeyValuePair<string,string> ("durata", du),
                        new KeyValuePair<string,string> ("livello", l),
                        new KeyValuePair<string,string> ("lunghezza", lu),
                        new KeyValuePair<string,string> ("user", Utility.Settings.User),
                    });

                    //inoltro richiesta al server
                    HttpClient client = new HttpClient();
                    var response = await client.PostAsync(uri, content);
                    var risp = await response.Content.ReadAsStringAsync();  //risposta del server
                    String s = risp.Trim();
                    if (s.Equals("1"))
                    {
                        DisplayAlert("Alert", "Percorso aggiunto", "OK");
                        await Navigation.PopToRootAsync();
                    }

                }
                else
                {
                    DisplayAlert("Alert", "Livello di difficoltà non compreso tra 1 e 5", "OK");

                }
                
            }
            else
            {
                DisplayAlert("Errore", "Riempire tutti i campi", "OK");
            }
            

        }
    }
}
