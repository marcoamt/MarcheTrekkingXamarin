using System;
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
            for (int i = 0; i < latitudine.Count; i++)
                mappa = latitudine[i] + ", " + longitudine[i];
        }

        //async
        protected async void aggiungi(object sender, EventArgs args)
        {

            string n = nome.Text;
            string d = descrizione.Text;
            string lu = lunghezza.Text;
            string l = livello.Text;
            string du = durata.Text;

            var uri = "http://marchetrekking.altervista.org/aggiungi_percorso.php";

            //body della post request
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string> ("nome", n),
                new KeyValuePair<string,string> ("desc", d),
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
                await Navigation.PushAsync(new Home());
            }

        }
    }
}
