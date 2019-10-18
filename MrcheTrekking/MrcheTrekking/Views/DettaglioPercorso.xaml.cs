using System;
using System.Collections.Generic;
using MrcheTrekking.Models;
using MrcheTrekking.ViewModels;
using Xamarin.Forms;

namespace MrcheTrekking.Views
{
    public partial class DettaglioPercorso : ContentPage
    {

        public DettaglioPercorso()
        {
            InitializeComponent();
            
        }

        protected async void GoMappa(object sender, EventArgs args)
        {
            //vado alla pagina che farà vedere la mappa passando come parametro le coordinate contenute nel database
            var binding = BindingContext;
            if(binding is MyDettaglioPercorsoViewModel)
            {
                await Navigation.PushAsync(new Mappa(((MyDettaglioPercorsoViewModel)binding).Item.Mappa));
            }
            else
            {
                await Navigation.PushAsync(new Mappa(((DettaglioPercorsoViewModel)binding).Item.Mappa));
            }
            
        }
        protected async void GoRecensioni(object sender, EventArgs args)
        {
            //passo il nome del percorso alla pagina delle recensioni
            
            var binding = (DettaglioPercorsoViewModel)BindingContext;
            var recensione = new RecensionePercorso();
            recensione.BindingContext = new ListRecensioneViewModel(binding.Item.Nome);
            await Navigation.PushAsync(recensione);
        }
    }
}
