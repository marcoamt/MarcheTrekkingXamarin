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
            prosegui.IsEnabled = false;
            undo.IsEnabled = false;
        }

        protected void Add(object sender, EventArgs args)
        {
            prosegui.IsEnabled = true;
            undo.IsEnabled = true;
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

        protected void Undo(object sender, EventArgs args)
        {
            var flag = i;
            agg.Children.RemoveAt(flag-1);
            i--;

            if (agg.Children.Count == 0)
            {
                prosegui.IsEnabled = false;
                undo.IsEnabled = false;
            }
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
                Entry lon = (Xamarin.Forms.Entry)row.Children[2];
                latitudine.Add(lat.Text);
                longitudine.Add(lon.Text);
            }

            //verifico che tutti i campi di lat e long siano stati inseriti prima di continuare
            bool ok = true;
            for (int l=0; l<latitudine.Count; l++)
            {
                if(!string.IsNullOrEmpty(latitudine[l]) && !string.IsNullOrEmpty(longitudine[l]))
                {
                    ok = true;
                }
                else
                {
                    ok = false;
                    break;
                }
                        
            }
            
            //passare alla prossima view per aggiungere i dettagli del percorso creato
            if(ok)
            {
                await Navigation.PushAsync(new ContinuaAggPercorso(latitudine, longitudine));
            }
            else
            {
                DisplayAlert("Alert", "Completa i campi", "OK");
            }
        }
    }
}
