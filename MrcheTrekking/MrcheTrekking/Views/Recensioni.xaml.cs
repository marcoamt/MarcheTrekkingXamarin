using System;
using System.Collections.Generic;
using System.Net.Http;
using MrcheTrekking.ViewModels;
using Xamarin.Forms;

namespace MrcheTrekking.Views
{
    public partial class Recensioni : ContentPage
    {
        public Recensioni()
        {
            BindingContext = new ListPercorsiViewModel();
            InitializeComponent();
        }

        protected async void Aggiungi(object sender, EventArgs args)
        {
            string nomePercorso = Picker.SelectedItem.ToString();
            string recensione = feedback.Text;

            var uri = "http://marchetrekking.altervista.org/aggiungi_recensione.php";

            //body della post request
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string> ("percorso", nomePercorso),
                new KeyValuePair<string,string> ("recensione", recensione),
                new KeyValuePair<string,string> ("user", Utility.Settings.User),
            });

            //inoltro richiesta al server
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(uri, content);
            var risp = await response.Content.ReadAsStringAsync();  //risposta del server
            String s = risp.Trim();
            if (s.Equals("1"))
            {
                DisplayAlert("Alert", "Recensione aggiunta", "OK");
            }

        }
    }
}
