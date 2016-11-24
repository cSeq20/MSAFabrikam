using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace Fabrikam.ViewModel
{
    class MenuTable
    {
        [JsonProperty(PropertyName ="Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "MenuName")]
        public string MenuName { get; set; }

        [JsonProperty(PropertyName = "Desc")]
        public string Desc { get; set; }

        [JsonProperty(PropertyName = "TotalPrice")]
        public double TotalPrice { get; set; }
    }
}
