using System;
using System.Collections.Generic;
using System.Text;

namespace TamagotchiUI.DTO
{
    class ActivityDTO
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public int? JoyAdd { get; set; }
        public int? CleanAdd { get; set; }

        //public virtual FoodDTO Food { get; set; }
       
    }
}
