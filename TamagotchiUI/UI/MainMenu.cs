using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using TamagotchiUI.WebServices;
using System.Threading.Tasks;
using TamagotchiUI.DTO;
using Tamagotchi.UI;

namespace Tamagotchi.UI
{
    class MainMenu: Menu
    {
        public MainMenu() : base($"Main Menu - {UIMain.CurrentPlayer.UserName} is logged in")
        {
            //build items in main menu!
            this.AddItem("profile", new PlayerScreen());
            this.AddItem("Feed", new Hunger());
            this.AddItem("Clean", new Clean());
            this.AddItem("Change datails", new ChangeDetails());
            



        }
    }
}
