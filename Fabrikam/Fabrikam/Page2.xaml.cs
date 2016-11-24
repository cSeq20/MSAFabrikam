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

        //async void add() {
        //    MenuTable test = new MenuTable()
        //    {
        //        MenuName = "Menu 3",
        //        Desc = "Hello World",
        //        TotalPrice = 30
        //    };

        //   await AzureManager.AzureManagerInstance.AddMenu(test);

        //}

        public async void DeleteMenu(object sender, EventArgs e)
        {
            var selected = (MenuItem)sender;
            var selectedItem = selected.CommandParameter as MenuTable;
            await AzureManager.AzureManagerInstance.RemoveMenu(selectedItem);
            LoadData();
        }

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
