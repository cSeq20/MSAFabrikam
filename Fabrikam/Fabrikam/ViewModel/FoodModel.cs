using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrikam.ViewModel
{
    public class FoodModel
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        public FoodModel()
        {
        }
    }

    public class GroupedFoodModel : ObservableCollection<FoodModel>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
    }
}