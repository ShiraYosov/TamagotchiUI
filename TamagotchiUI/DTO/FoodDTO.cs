using System;
using System.Collections.Generic;
using System.Text;
using TamagotchiUI.WebServices;

namespace TamagotchiUI.DTO
{
    class FoodDTO
    {
        public int FoodId { get; set; }
        public int? SatiatyLevel { get; set; }
        public int? Calories { get; set; }
        
        //public virtual Activity FoodNavigation { get; set; }
    }

}
}
