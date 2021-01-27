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
    class LoginScreen: Screen
    {
        const int DEAD = 1;
        public LoginScreen() : base("Login")
        {

        }

        public override void Show()
        {
            //Clear screen and set title (implemented by Screen Show)
            base.Show();
            try
            {
                //Check if we should logout first

                if (UIMain.CurrentPlayer != null)
                {
                    Console.WriteLine($"Currently, {UIMain.CurrentPlayer.UserName} is logged in. Press L to log out or other key to go back to menu!");
                    char c = Console.ReadKey().KeyChar;
                    if (c == 'L' || c == 'l')
                    {
                        //Save all changes to DB before logging out
                        
                        UIMain.CurrentPlayer = null;
                    }
                }

                //if user is still logged in, we should go out!= back to menu
                while (UIMain.CurrentPlayer == null)
                {
                    //Clear screen again
                    base.Show();

                    Console.WriteLine($"Please enter your user name: ");
                    string uName = Console.ReadLine();
                    Console.WriteLine($"Please enter your password: ");
                    string password = Console.ReadLine();

                    Task<PlayerDTO> tt = UIMain.api.Login(uName,password);
                    tt.Wait();
                    UIMain.CurrentPlayer = tt.Result;
                   
                    if (UIMain.CurrentPlayer != null)
                    {
                        Console.WriteLine("Login was done successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Could not login!!! Please fix it and run again!");
                        Environment.Exit(0);
                    }

                   
                    //else
                    //{
                    //    IEnumerable<Pet> petList = from p in UIMain.CurrentPlayer.Pets where (p.StatusId != DEAD) select p;
                    //    UIMain.CurrentPet = petList.FirstOrDefault();
                    //}

                }
                //Show main menu once user is logged in
                //MainMenu menu = new MainMenu();
                //menu.Show();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fail with error: {e.Message}!");
            }
        }
    }
}

