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
            MainPage = new NavigationPage((ContentPage)ViewFactory.CreatePage<percorsiViewModel, Home>());
        }
        private void RegisterViews()
        {
            ViewFactory.Register<Home, percorsiViewModel>();
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
