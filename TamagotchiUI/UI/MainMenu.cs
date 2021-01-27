using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using TamagotchiUI.WebServices;
using System.Threading.Tasks;
using TamagotchiUI.DTO;

namespace Tamagotchi.UI
{
    class MainMenu: Menu
    {
        public MainMenu() : base($"Main Menu - {UIMain.CurrentPlayer.UserName} is logged in")
        {
            //Build items in main menu!
            //AddItem("Profile", new PlayerScreen());
            //AddItem("Last Actions", new LastActions());
            //AddItem("Current Animal Measures", new AnimalMeasures());
           

        }
    }
}
