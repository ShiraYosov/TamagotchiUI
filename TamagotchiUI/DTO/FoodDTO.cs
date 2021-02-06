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
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public int? JoyAdd { get; set; }
        public int? CleanAdd { get; set; }

       
    }

}

