using System;
using System.Collections.Generic;
using System.Text;
using Tamagotchi.UI;
using System.Threading.Tasks;

namespace TamagotchiUI.DTO
{
    class PlayerDTO
    {

        public int PlayerId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }

        public int? PetId { get; set; }
        //public virtual PetDTO Pet { get; set; }
        public virtual ICollection<PetDTO> Pets { get; set; }

       
        public PlayerDTO() { }
    }
}
