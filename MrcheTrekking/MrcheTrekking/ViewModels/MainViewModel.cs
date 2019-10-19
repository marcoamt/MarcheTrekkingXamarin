using System;
using System.Windows.Input;
using MrcheTrekking.Views;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace MrcheTrekking.ViewModels
{
    public class MainViewModel: ViewModel
    {
        public ICommand Accedi { get; private set; }
        public ICommand Registrati { get; private set; }
        public INavigation Navigation { get; set; }

        public MainViewModel(INavigation navigation)
        {

            Navigation = navigation;
            Accedi = new Command(async () => {
                await Navigation.PushAsync(new Login());
            });

            Registrati = new Command(async () => {
                await Navigation.PushAsync(new Registrati());
            });
        }
    }
}
