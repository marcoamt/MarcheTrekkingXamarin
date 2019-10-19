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
            returnType: typeof(System.Windows.Input.ICommand),
            declaringType: typeof(Percorsi),
            defaultValue: null);

        public ICommand ItemSelectedCommand
        {
            get { return (System.Windows.Input.ICommand)GetValue(ItemSelectedCommandProperty); }
            set { SetValue(ItemSelectedCommandProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            
            RemoveBinding(ItemSelectedCommandProperty);
            SetBinding(ItemSelectedCommandProperty, new Binding(ItemSelectedCommandPropertyName));
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PercorsiViewModel;
            if (item == null)
            {
                // the item was deselected
                return;
            }

            // Navigate to the detail page
            var detailvm = new DettaglioPercorsoViewModel(item);
            var detail = new DettaglioPercorso();
            detail.BindingContext = detailvm;
            await Navigation.PushAsync(detail);

            // Manually deselect item
            lstView.SelectedItem = null;
        }

        public Percorsi()
        {
            BindingContext = new ListPercorsiViewModel();
           
            InitializeComponent();
        }
    }
}
