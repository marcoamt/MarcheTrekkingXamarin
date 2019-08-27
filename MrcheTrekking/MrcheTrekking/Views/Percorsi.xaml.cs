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
    public partial class Percorsi : ContentPage
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


        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PercorsiViewModel;
            if (item == null)
            {
                // the item was deselected
                return;
            }

            // Navigate to the detail page
            await Navigation.PushAsync(new DettaglioPercorso(new DettaglioPercorsoViewModel(item)));

            // Manually deselect item
            //characterList.SelectedItem = null;
        }

        //private List<PercorsiModel> Items;
        public Percorsi()
        {
            BindingContext = new ListPercorsiViewModel();
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
