using System;
using System.Collections.Generic;
using System.Linq;
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
            string c = datadinascita.Text;

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
            });

            //inoltro richiesta al server
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(uri, content);
            var risp = await response.Content.ReadAsStringAsync();  //risposta del server
            String s = risp.Trim();
            if(s.Equals("1"))
            {
                MrcheTrekking.Utility.Settings.User = u;    //uso del pacchetto nuget Xamarin Settings per abilitare una "sessione"
                Navigation.InsertPageBefore(new Home(), this);
                await Navigation.PopAsync();    //rimuove la precedente pagina dallo stack
            }

         }
	}
}