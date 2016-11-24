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

        public async Task RemoveMenu(MenuTable menuTable)
        {
            await this.menuTable.DeleteAsync(menuTable);
        }

        public async Task AddMenu(MenuTable menuTable)
        {
            await this.menuTable.InsertAsync(menuTable);
        }

        public async Task<IEnumerable<MenuTable>> GetMenu()
        {
            return await this.menuTable.ToEnumerableAsync();
        }
    }
}