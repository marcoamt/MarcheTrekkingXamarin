using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MrcheTrekking.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registrati : ContentPage
	{
		public Registrati ()
		{
			InitializeComponent ();
            datadinascita.Date = new DateTime(day: 31, month: 12, year:2005);
            datadinascita.Format = "dd/MM/yyyy"; 
		}
         //async
        protected async void Reg(object sender, EventArgs args)
        {
            
            string n = nome.Text;
            string c = cognome.Text;
            string e = email.Text;
            string u = username.Text;
            string t = telefono.Text;
            string p = password.Text;
            string d ="";
            if(datadinascita.Date.Year <= 2005)
            {
                d = datadinascita.Date.Year.ToString() + "/" + datadinascita.Date.Month.ToString() + "/" + datadinascita.Date.Day.ToString();
            }
            else
            {
                DisplayAlert("Errore", "Data di nascita non valida", "OK");
                return;
            }
            


            if(!string.IsNullOrEmpty(n) && !string.IsNullOrEmpty(c) && !string.IsNullOrEmpty(e) && !string.IsNullOrEmpty(u) && !string.IsNullOrEmpty(t) && !string.IsNullOrEmpty(p))
            {
                var uri = "http://marchetrekking.altervista.org/aggiungi_utente.php";

                //body della post request
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string> ("user", u),
                    new KeyValuePair<string,string> ("pass", p),
                    new KeyValuePair<string,string> ("mail", e),
                    new KeyValuePair<string,string> ("n", n),
                    new KeyValuePair<string,string> ("c", c),
                    new KeyValuePair<string,string> ("telef", t),
                    new KeyValuePair<string,string> ("dnascita", d),
                });

                //inoltro richiesta al server
                HttpClient client = new HttpClient();
                var response = await client.PostAsync(uri, content);
                var risp = await response.Content.ReadAsStringAsync();  //risposta del server
                String s = risp.Trim();
                if(s.Equals("1"))
                {
                    MrcheTrekking.Utility.Settings.User = u;    //uso il pacchetto nuget Xamarin Settings per abilitare una "sessione"
                    Navigation.InsertPageBefore(new Home(), this);
                    await Navigation.PopAsync();    //rimuove la precedente pagina dallo stack
                }
            }
            else
            {
                DisplayAlert("Errore", "Riempire tutti i campi", "OK");
            }

        }
	}
}