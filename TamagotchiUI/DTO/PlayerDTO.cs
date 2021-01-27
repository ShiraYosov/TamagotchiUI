using System;
using System.Collections.Generic;
using System.Text;

namespace TamagotchiUI.DTO
{
    class PlayerDTO
    {
        // HI 
        public int PlayerId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        
        public int PetId { get; set; }

        public PlayerDTO() { }
    }
}
