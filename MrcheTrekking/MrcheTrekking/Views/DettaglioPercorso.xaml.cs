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
        private MyDettaglioPercorsoViewModel mdp;

        public DettaglioPercorso(object dp)
        {
            InitializeComponent();
            if (dp is DettaglioPercorsoViewModel)
            {
                BindingContext = this.dp = (DettaglioPercorsoViewModel)dp;
            }
            else
            {
                BindingContext = this.mdp = (MyDettaglioPercorsoViewModel)dp;
                Recensione.IsVisible = false;
            }
        }

        protected async void GoMappa(object sender, EventArgs args)
        {
            //vado alla pagina che farà vedere la mappa passando come parametro le coordinate contenute nel database
            if(dp is null)
            {
                await Navigation.PushAsync(new Mappa(mdp.Item.Mappa));
            }
            else
            {
                await Navigation.PushAsync(new Mappa(dp.Item.Mappa));
            }
        }
        protected async void GoRecensioni(object sender, EventArgs args)
        {
            //passo il nome del percorso alla pagina delle recensioni
            if (dp is null)
            {
                await Navigation.PushAsync(new RecensionePercorso(mdp.Item.Nome));
            }
            else
            {
                await Navigation.PushAsync(new RecensionePercorso(dp.Item.Nome));
            }
        }
    }
}
