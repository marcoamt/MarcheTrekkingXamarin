using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace MrcheTrekking.Views
{
    public partial class ContinuaAggPercorso : ContentPage
    {
        public ContinuaAggPercorso(List<string> latitudine, List<string> longitudine)
        {
            InitializeComponent();
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
                new KeyValuePair<string,string> ("durata", du),
                new KeyValuePair<string,string> ("livello", l),
                new KeyValuePair<string,string> ("lunghezza", lu),
            });

            //inoltro richiesta al server
            /*HttpClient client = new HttpClient();
            var response = await client.PostAsync(uri, content);
            var risp = await response.Content.ReadAsStringAsync();  //risposta del server
            String s = risp.Trim();
            if (s.Equals("1"))
            {
                MrcheTrekking.Utility.Settings.User = u;    //uso del pacchetto nuget Xamarin Settings per abilitare una "sessione"
                Navigation.InsertPageBefore(new Home(), this);
                await Navigation.PopAsync();    //rimuove la precedente pagina dallo stack
            }*/

        }
    }
}
