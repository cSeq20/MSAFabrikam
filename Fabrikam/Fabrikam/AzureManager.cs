using Fabrikam.ViewModel;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fabrikam
{
    class AzureManager
    {
        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<MenuTable> menuTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("http://fabrikammsa.azurewebsites.net/");
            this.menuTable = this.client.GetTable<MenuTable>();
        }   

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        /**
         * Delete data from table
         */
        public async Task RemoveMenu(MenuTable menuTable)
        {
            await this.menuTable.DeleteAsync(menuTable);
        }

        /**
         * Add a menutable item to the table in azure 
         */
        public async Task AddMenu(MenuTable menuTable)
        {
            await this.menuTable.InsertAsync(menuTable);
        }

        /**
         * Get all items from azure table and return a enumarable. 
         */
        public async Task<IEnumerable<MenuTable>> GetMenu()
        {
            return await this.menuTable.ToEnumerableAsync();
        }
    }
}