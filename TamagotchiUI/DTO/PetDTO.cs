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

        public string GetStatus()
        {
            Task<string> t = UIMain.api.GetStatus((int)this.StatusId);
            t.Wait();
            return t.Result;
        }

        //    public virtual Clean Clean { get; set; }
        //    public virtual Hunger Hunger { get; set; }
        //    public virtual Joy Joy { get; set; }
        //    public virtual LifeCircle LifeTime { get; set; }
        //    public virtual Player Player { get; set; }
        //    public virtual PetStatus Status { get; set; }
        //    public virtual ICollection<PetActivity> PetActivities { get; set; }
        //    public virtual ICollection<Player> Players { get; set; }
        //}
    }
}
