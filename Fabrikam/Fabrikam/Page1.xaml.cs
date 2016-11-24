using Fabrikam.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace Fabrikam
{
    public partial class Page1 : ContentPage
    {
        private ObservableCollection<GroupedFoodModel> grouped { get; set; }
        public string foodNames = "";   // for description
        public string menuTitle;    // for menu name
        public double total;    // for total price
        public Page1()
        {
            InitializeComponent();

            grouped = new ObservableCollection<GroupedFoodModel>();
            //group1
            var MainGroup = new GroupedFoodModel() { LongName = "Main", ShortName = "M" };
            //group 2
            var SideGroup = new GroupedFoodModel() { LongName = "Sides", ShortName = "S" };
            //group 3
            var DrinkGroup = new GroupedFoodModel() { LongName = "Drinks", ShortName = "D" };
            // create set of items in each group
            MainGroup.Add(new FoodModel() { Name = "Pizza", Price = 9.99, Comment = "Choice of chicken, cheese or pepporoni pizza with a range of sauces and vegetables", Image = "ic_pizza" });
            MainGroup.Add(new FoodModel() { Name = "Pasta", Price = 12.00, Comment = "Freshly made pasta, with cheese and a selection of sauces", Image = "ic_pasta" });
            MainGroup.Add(new FoodModel() { Name = "Burger", Price = 7.99, Comment = "Choice of chicken, fish or lamb burger with cheese, and salads", Image = "ic_burger" });
            MainGroup.Add(new FoodModel() { Name = "Steak", Price = 14.99, Comment = "Lamb steak marinated with sauce of choice. Comes with fresh salad.", Image = "ic_steak" });
            MainGroup.Add(new FoodModel() { Name = "Fish and Chips", Price = 11.99, Comment = "Choice of two snapper or hoki fillets, and freshly made chips", Image = "ic_fish" });
            SideGroup.Add(new FoodModel() { Name = "Fries", Price = 2.99, Comment = "Freshly made fries with a range of sauces", Image = "ic_fries" });
            SideGroup.Add(new FoodModel() { Name = "Soup", Price = 4.99, Comment = "Choice of vegetable, chicken and tamato soup.  Comes with dipping bread", Image = "ic_soup" });
            SideGroup.Add(new FoodModel() { Name = "Salad", Price = 4.99, Comment = "Assortment of fresh salad and fruit", Image = "ic_salad" });
            DrinkGroup.Add(new FoodModel() { Name = "Beer", Price = 4.99, Comment = "Choice from a range of beer", Image = "ic_beer" });
            DrinkGroup.Add(new FoodModel() { Name = "Wine", Price = 4.99, Comment = "Choice from a range of wine", Image = "ic_wine" });
            DrinkGroup.Add(new FoodModel() { Name = "Soft Drink", Price = 2.99, Comment = "Choice from a range of soft drinks", Image = "ic_softdrink" });
            // add to observable collection
            grouped.Add(MainGroup);
            grouped.Add(SideGroup);
            grouped.Add(DrinkGroup);

            MenuItemsList.ItemsSource = grouped;
            MenuItemsList.GroupShortNameBinding = new Binding("ShortName");

            Content = MenuItemsList;
        }

        /**
         * adds the chosen food items to a menu and shows a alert with food and toal price 
         */
       public async void AddtoMenu(object sender, EventArgs e)
        {
            var selected = (MenuItem)sender;
            var selectedItem = selected.CommandParameter as FoodModel;
            foodNames += selectedItem.Name + "\n";
            total += selectedItem.Price;
            await DisplayAlert("Menu", $"Price is {total} and Items are {foodNames}", "Ok");
        }

        /* 
         * Adds to menu table in azure
         */ 
        public async void AddItem(object sendeer, EventArgs e)
        {
            PromptConfig popup = new PromptConfig(); // to setup a prompt
            popup.SetOkText("Ok");
            popup.SetMessage("Enter a menu title");
            // Promt user for menu title
            PromptResult test = await UserDialogs.Instance.PromptAsync(popup);
            
            menuTitle = test.Text;  // get the user input for the menu title field
            // new menuTable object
            MenuTable mt = new MenuTable()
            {
                MenuName = menuTitle,
                Desc = foodNames,
                TotalPrice = total  
            };
            // add items to azure table
            await AzureManager.AzureManagerInstance.AddMenu(mt);
            
        }
    }
}
