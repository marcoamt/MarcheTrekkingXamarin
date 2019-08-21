using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MrcheTrekking.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MrcheTrekking.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Percorsi : ContentPage
	{

        //private List<Percorsi> Items;
		public Percorsi ()
		{
			InitializeComponent ();

            /*var cell = new DataTemplate(typeof(ImageCell));

            cell.SetBinding(TextCell.TextProperty, "Name");
            cell.SetBinding(TextCell.DetailProperty, "Descrizione");
            cell.SetBinding(ImageCell.ImageSourceProperty, "Immagine");

            listPercorsi.ItemTemplate = cell;

            ;*/

            //this.BindingContext = new percorsiViewModel();
            ListView lv = new ListView();
            DataTemplate dt = new DataTemplate(typeof(TextCell));
            dt.SetBinding(TextCell.TextProperty, new Binding("Nome"));
            dt.SetBinding(TextCell.DetailProperty, new Binding("Descrizione"));
            lv.ItemTemplate = dt;

            this.Content = new StackLayout
            {
                Children =
                {
                    lv
                }
            };
        }

        
	}
}