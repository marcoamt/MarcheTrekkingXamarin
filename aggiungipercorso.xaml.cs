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
	public partial class Aggiungipercorso : ContentPage
	{
		public Aggiungipercorso ()
		{
			InitializeComponent ();
		}
         //async
        protected async void Agg(object sender, EventArgs args)
        {
        string[] row = { log.Text, lat.Text };
        var listViewItem = new ListViewItem(row); 
        listView1.Items.Add(listViewItem);
        }

         protected async void Cont(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Continua());
        }
    }

}