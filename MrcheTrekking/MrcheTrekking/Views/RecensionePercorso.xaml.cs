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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecensionePercorso : ContentPage
    {
        public static BindableProperty ItemSelectedCommandProperty = BindableProperty.Create(
            propertyName: "ItemSelectedCommand",
            returnType: typeof(ICommand),
            declaringType: typeof(Recensioni),
            defaultValue: null);
        
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            RemoveBinding(ItemSelectedCommandProperty);
            SetBinding(ItemSelectedCommandProperty, new Binding(ItemSelectedCommandPropertyName));
        }

        /*private void HandleItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var command = ItemSelectedCommand;
            if (command != null && command.CanExecute(e.SelectedItem))
            {
                command.Execute(e.SelectedItem);
            }
        }*/


        //private List<PercorsiModel> Items;
        public RecensionePercorso()
        {
            BindingContext = new ListRecensioneViewModel();
            InitializeComponent();

            //GetPercorsi();
            
        }

        /*public async Task GetPercorsi()
        {
            try
            {
                var uri = new Uri("http://marchetrekking.altervista.org/percorsiJSON.php");
                HttpClient myClient = new HttpClient();

                var response = await myClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var Items = JsonConvert.DeserializeObject<List<PercorsiModel>>(content);
                    int name = Items.Count;
                    lstView.ItemsSource = Items;
                }
                else
                {
                    Application.Current.Properties["response"] = response;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        protected async void onItemTapped(object sender, ItemTappedEventArgs e)
        {
            Debug.WriteLine("Tapped: " + e.Item);
            //disabilito l'evidenziatore dall'elemento selezionato
            if (sender is ListView lv) lv.SelectedItem = null;
            //passo alla view del dettaglio del percorso selezionato
            await Navigation.PushAsync(new DettaglioPercorso(e.Item));
        }*/
    }
}