using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MrcheTrekking.ViewModels;
using Xamarin.Forms;
using MrcheTrekking.Models;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MrcheTrekking.Views
{
    public partial class MieiPercorsi : ContentPage
    {
        public const string ItemSelectedCommandPropertyName = "ItemSelectedCommand";
        public static BindableProperty ItemSelectedCommandProperty = BindableProperty.Create(
            propertyName: "ItemSelectedCommand",
            returnType: typeof(ICommand),
            declaringType: typeof(Percorsi),
            defaultValue: null);

        public ICommand ItemSelectedCommand
        {
            get { return (ICommand)GetValue(ItemSelectedCommandProperty); }
            set { SetValue(ItemSelectedCommandProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            RemoveBinding(ItemSelectedCommandProperty);
            SetBinding(ItemSelectedCommandProperty, new Binding(ItemSelectedCommandPropertyName));
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as MyPercorsiViewModel;
            if (item == null)
            {
                // the item was deselected
                return;
            }

            
            
            // Navigate to the detail page
            await Navigation.PushAsync(new DettaglioPercorso(new MyDettaglioPercorsoViewModel(item)));

            // Manually deselect item
            lstView.SelectedItem = null;
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            //DisplayAlert("Delete", " sicuro di voler cancellare ", "OK");
            var item = mi.BindingContext as MyPercorsiViewModel;
            bool answer = await DisplayAlert("Conferma", "Vuoi cancellare questo percorso?", "Si", "No");
            if (answer)
            {
                var uri = "http://marchetrekking.altervista.org/cancellaPercorso.php";

                //body della post request
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string> ("percorso", item.Id.ToString()),
                    });

                //inoltro richiesta al server
                HttpClient client = new HttpClient();
                var response = await client.PostAsync(uri, content);
                var risp = await response.Content.ReadAsStringAsync();  //risposta del server
                string s = risp.Trim();
                if (s.Equals("ok"))
                {
                    DisplayAlert("Alert", "Percorso cancellato", "OK");

                    //update del contenuto di questa pagina
                    var vUpdatedPage = new MieiPercorsi();
                    Navigation.InsertPageBefore(vUpdatedPage, this);
                    _ = Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Errore", "Errore", "OK");
                }
            }

        }

        public MieiPercorsi()
        {
            BindingContext = new ListMyPercorsiViewModel();
            InitializeComponent();
        }
    }
}