using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MrcheTrekking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
        }
        //async
        protected async void Log(object sender, EventArgs args)
        {
            
            string u = username.Text;
            string p = password.Text;

            var uri = "http://marchetrekking.altervista.org/login.php";

            //body della post request
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string> ("username", u),
                new KeyValuePair<string,string> ("password", p),
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