using System;
using System.Collections.Generic;
using System.Text;
using TamagotchiUI.WebServices;
using Tamagotchi.UI;
using System.Threading.Tasks;

namespace TamagotchiUI.DTO
{
    class PetDTO
    {
        public int PetId { get; set; }
        public int? PlayerId { get; set; }
        public string PetName { get; set; }
        public int? HungerId { get; set; }
        public int? JoyId { get; set; }
        public int? CleanId { get; set; }
        public int? StatusId { get; set; }
        public int? LifeTimeId { get; set; }
        public DateTime? BirthDate { get; set; }
        public double? PetAge { get; set; }
        public double? PetWeight { get; set; }

        public PetDTO() { }

        public string GetStatus()
        {
            Task<string> t = UIMain.api.GetStatus((int)this.StatusId);
            t.Wait();
            return t.Result;
        }

        public string GetCleanLevel()
        {
            Task<string> t = UIMain.api.GetCleanLevel((int)this.CleanId);
            t.Wait();
            return t.Result;
        }

        public string GetJoyLevel()
        {
            Task<string> t = UIMain.api.GetJoyLevel((int)this.JoyId);
            t.Wait();
            return t.Result;
        }

        public string GetHungerLevel()
        {
            Task<string> t = UIMain.api.GetHungerLevel((int)this.HungerId);
            t.Wait();
            return t.Result;
        }


    }
}
