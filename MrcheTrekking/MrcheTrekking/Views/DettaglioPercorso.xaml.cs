using System;
using System.Collections.Generic;
using MrcheTrekking.Models;
using MrcheTrekking.ViewModels;
using Xamarin.Forms;

namespace MrcheTrekking.Views
{
    public partial class DettaglioPercorso : ContentPage
    {
        private DettaglioPercorsoViewModel dp;

        public DettaglioPercorso(DettaglioPercorsoViewModel dp)
        {
            InitializeComponent();

            BindingContext = this.dp = dp;
        }

        protected async void GoMappa(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Mappa());
        }
        protected async void GoRecensioni(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new RecensionePercorso(dp.Item.Nome));
        }
    }
}
