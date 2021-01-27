using System;
using TamagotchiUI.WebServices;
using TamagotchiUI.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tamagotchi.UI;

namespace TamagotchiUI
{
    class Program
    {
        static void Main(string[] args)
        {
           
            UIMain ui = new UIMain(new LoginScreen());
            ui.ApplicationStart();

            Console.ReadKey();


        }
    }
}
