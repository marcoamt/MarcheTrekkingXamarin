﻿using System;
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
    public partial class MieiPercorsi : ContentPage
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

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PercorsiViewModel;
            if (item == null)
            {
                // the item was deselected
                return;
            }
            item.Immagine = "logo";

            
            
            // Navigate to the detail page
            await Navigation.PushAsync(new DettaglioPercorso(new DettaglioPercorsoViewModel(item)));

            // Manually deselect item
            lstView.SelectedItem = null;
        }

        public MieiPercorsi()
        {
            BindingContext = new ListMyPercorsiViewModel();
            InitializeComponent();
        }
    }
}