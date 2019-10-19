using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using try2.Models;
using try2.Views;
using try2.ViewModels;

namespace try2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        List<Item> items;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
            SetupData();
            listView.ItemsSource = items;
        }

        private void SetupData()
        {
            items = new List<Item>();
            items.Add(new Item
            {
                Name = "Item No. 1",
                Id = "1",
                Text = "Item 1",
                Description = "item number 1"
            });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Item;
            if (listView.SelectedItem != null)
            {
                var detailPage = new DetailPage();
                detailPage.BindingContext = e.SelectedItem as Item;
                listView.SelectedItem = null;
                await Navigation.PushModalAsync(detailPage);
            }

            var item2 = e.SelectedItem as Item;
            if (item2 == null)
                return;

            await Navigation.PushModalAsync(new DetailPage());

            // Manually deselect item.
            ItemsListView.SelectedItem = null;

        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}