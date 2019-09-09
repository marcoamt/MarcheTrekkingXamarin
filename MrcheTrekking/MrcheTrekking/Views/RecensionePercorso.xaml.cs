using MrcheTrekking.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

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


        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            RemoveBinding(ItemSelectedCommandProperty);
            SetBinding(ItemSelectedCommandProperty, new Binding(ItemSelectedCommandPropertyName));
        }

        public RecensionePercorso(string p)
        {
            BindingContext = new ListRecensioneViewModel(p);
            
            InitializeComponent();
        }

        
        /*public void CheckList()
        {
            if (c == 0)
            {
                //await Navigation.PopAsync();
                DisplayAlert("Alert", "Nessuna Recensione", "OK");
            }
        }*/
    }
}
