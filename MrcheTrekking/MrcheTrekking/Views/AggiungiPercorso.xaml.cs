using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MrcheTrekking.Views
{
    public partial class AggiungiPercorso : ContentPage
    {
        private int i = 0;
        private List<string> latitudine, longitudine;
        public AggiungiPercorso()
        {
            InitializeComponent();
        }

        protected void Add(object sender, EventArgs args)
        {
            var row = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.FillAndExpand};
            var l = new Label{ Text = "Coordinate" + i};
            Entry lat = new Entry { Placeholder = "Latitudine"};
            Entry lon = new Entry { Placeholder = "Longitudine" };
            row.Children.Add(l);
            row.Children.Add(lat);
            row.Children.Add(lon);
            agg.Children.Add(row);
            i++;
        }

        protected async void Continua(object sender, EventArgs args)
        {
            int children = agg.Children.Count;
            latitudine = new List<string>();
            longitudine = new List<string>();
            for (int c=0; c< children; c++)
            {
                StackLayout row = (Xamarin.Forms.StackLayout)agg.Children[c];
                Entry lat = (Xamarin.Forms.Entry)row.Children[1];
                latitudine.Add(lat.Text);
                Entry lon = (Xamarin.Forms.Entry)row.Children[2];
                longitudine.Add(lon.Text);
            }

            //passare alla prossima view per aggiungere i dettagli del percorso creato

            await Navigation.PushAsync(new ContinuaAggPercorso(latitudine, longitudine));
        }
    }
}
