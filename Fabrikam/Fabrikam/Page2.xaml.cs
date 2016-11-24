using Fabrikam.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Fabrikam
{
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
            LoadData();
            
        }

        public async void DeleteMenu(object sender, EventArgs e)
        {
            var selected = (MenuItem)sender;
            var selectedItem = selected.CommandParameter as MenuTable;
            await AzureManager.AzureManagerInstance.RemoveMenu(selectedItem);
            LoadData();
        }

        /**
         * Setup the listview with the table 
         */ 
        async void LoadData() {
            IEnumerable<MenuTable> menuTable = await AzureManager.AzureManagerInstance.GetMenu();
            menus.ItemsSource = menuTable;
        }

        private void refresh(object sender, EventArgs e)
        {
            LoadData();
            menus.IsRefreshing = false;
        }
        
    }
}
