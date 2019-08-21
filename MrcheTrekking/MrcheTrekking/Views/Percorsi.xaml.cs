using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MrcheTrekking.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Percorsi : ContentPage
	{
		public Percorsi ()
		{
			InitializeComponent ();

            var percorsi = GetPercorsiAsync();

            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        new ImageCell
                        {
                            // Some differences with loading images in initial release.
                            ImageSource =
                                ImageSource.FromUri(new Uri("http://xamarin.com/images/index/ide-xamarin-studio.png")),
                            Text = "This is an ImageCell",
                            Detail = "This is some detail text",
                        }
                    }
                }
            };

            this.Content = new StackLayout
            {
                Children =
                {
                    tableView
                }
            };
        }

        public async Task<List<Percorsi>> GetPercorsiAsync()
        {
            var uri = "http://marchetrekking.altervista.org/percorsi.php";

           

            //inoltro richiesta al server
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var risp = await response.Content.ReadAsStringAsync();  //risposta del server
                var Items = JsonConvert.DeserializeObject<List<Percorsi>>(risp);
                return Items;
            }
            else
            {
                return null;
            }
        }
	}
}