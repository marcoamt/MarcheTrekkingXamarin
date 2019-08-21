using Xamarin.Forms;
using MrcheTrekking.Views;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Mvvm;
using MrcheTrekking.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MrcheTrekking
{
    public partial class App : Application
    {
        public App()
        {
            // The root page of your application
            RegisterViews();
            if (MrcheTrekking.Utility.Settings.User.Equals("")) //verifico se l'utente è già loggato
            {
                //MainPage = new NavigationPage((ContentPage)ViewFactory.CreatePage<percorsiViewModel, Main>());
                MainPage = new NavigationPage(new Main());
            }
            else
            {
                MainPage = new NavigationPage(new Home());
            }
        }
        private void RegisterViews()
        {
            ViewFactory.Register<Percorsi, percorsiViewModel>();
            //ViewFactory.Register<Home, ContactDetailsViewModel>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
