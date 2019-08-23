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

namespace MrcheTrekking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Percorsi : ContentPage
    {

        ObservableCollection<PercorsiModel> PercorsiList { get; set; }

        //private List<PercorsiModel> Items;
        public Percorsi()
        {
            InitializeComponent();

            GetPercorsi();
            
        }

        public async Task GetPercorsi()
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
            await Navigation.PushAsync(new DettaglioPercorso(e.Item));
        }
    }
}
