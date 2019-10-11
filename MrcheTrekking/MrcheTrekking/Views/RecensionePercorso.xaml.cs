using MrcheTrekking.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using MrcheTrekking.Utility;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Collections.Generic;

namespace MrcheTrekking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecensionePercorso : ContentPage
    {
        public const string ItemSelectedCommandPropertyName = "ItemSelectedCommand";
        public static BindableProperty ItemSelectedCommandProperty = BindableProperty.Create(
            propertyName: "ItemSelectedCommand",
            returnType: typeof(ICommand),
            declaringType: typeof(Recensioni),
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

        private string percorsoCorrente;

        public RecensionePercorso(string p)
        {
            percorsoCorrente = p;
            BindingContext = new ListRecensioneViewModel(p);
            
            InitializeComponent();
        }

        async void OnAlertYesNoClicked(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as RecensioneViewModel;
            if (item == null)
            {
                // the item was deselected
                return;
            }
            bool answer = await DisplayAlert("Conferma", "Vuoi cancellare questa recensione?", "Si", "No");
            Debug.WriteLine("Answer: " + answer);
            if (answer)
            {
                if (Settings.User == item.UserName)
                {
                    Debug.WriteLine("ok" + Settings.User);
                    var uri = "http://marchetrekking.altervista.org/cancellaPercorso.php";

                    //body della post request
                    var content = new FormUrlEncodedContent(new[]
                    {
                    new KeyValuePair<string,string> ("recensione", item.Id.ToString()),
                    });

                    //inoltro richiesta al server
                    HttpClient client = new HttpClient();
                    var response = await client.PostAsync(uri, content);
                    var risp = await response.Content.ReadAsStringAsync();  //risposta del server
                    string s = risp.Trim();
                    if (s.Equals("ok"))
                    {
                        DisplayAlert("Alert", "Recensione cancellata", "OK");

                        //update del contenuto di questa pagina
                        var vUpdatedPage = new RecensionePercorso(percorsoCorrente);
                        Navigation.InsertPageBefore(vUpdatedPage, this);
                        _ = Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert("Errore", "Errore", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Alert", "Non puoi cancellare questa recensione", "Ok");
                }
            }
            lstView.SelectedItem = null;
        }
    }
}
