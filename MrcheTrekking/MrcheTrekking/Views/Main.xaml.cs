using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MrcheTrekking.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Main : ContentPage
	{
		public Main ()
		{
			InitializeComponent ();
		}

        protected async void Accedi(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Login());
        }

        protected async void Registrati(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Registrati());
        }
    }
}