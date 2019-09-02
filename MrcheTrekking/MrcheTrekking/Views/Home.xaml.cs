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
	public partial class Home : ContentPage
	{
        public Home ()
		{
			InitializeComponent ();
            User.Text = MrcheTrekking.Utility.Settings.User;
            var image = new Image { Source = "trekking.jpg" };
        }

        protected async void Percorsi(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Percorsi());
        }

        protected async void Logout(object sender, EventArgs args)
        {
            MrcheTrekking.Utility.Settings.User = "";
            Navigation.InsertPageBefore(new Main(), this);
            await Navigation.PopAsync();    //rimuove la precedente pagina dallo stack
        }

        protected async void AggiungiPercorso(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AggiungiPercorso());
        }

        protected async void Recensioni(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Recensioni());
        }

        protected async void MieiPercorsi(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MieiPercorsi());
        }




    }
}