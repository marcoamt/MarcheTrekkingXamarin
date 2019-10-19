using System;
using System.Windows.Input;
using MrcheTrekking.Views;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace MrcheTrekking.ViewModels
{
    public class HomeViewModel: ViewModel
    {
        public ICommand PercorsiCommand { get; private set; }
        public ICommand AggiungiPercorso { get; private set; }
        public ICommand Recensioni { get; private set; }
        public ICommand MieiPercorsi { get; private set; }

        public INavigation Navigation { get; set; }
        public string Username;

        public HomeViewModel(INavigation navigation)
        {
            Username = Utility.Settings.User;
            this.Navigation = navigation;
            PercorsiCommand = new Command(async () => {
                await navigation.PushAsync(new Percorsi());
            });

            AggiungiPercorso = new Command(async () => {
                await navigation.PushAsync(new AggiungiPercorso());
            });

            Recensioni = new Command(async () => {
                await navigation.PushAsync(new Recensioni());
            });

            MieiPercorsi = new Command(async () => {
                await navigation.PushAsync(new MieiPercorsi());
            });
        }
    }
}
