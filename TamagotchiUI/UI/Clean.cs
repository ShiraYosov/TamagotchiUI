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
    class Clean : Screen
    {
        const int FIRSTCLEAN = 6;
        const int LASTCLEAN = 11;
        const int DEAD = 1;
        public Clean() : base("Clean Pet")
        {

        }

        public override void Show()
        {
            base.Show();

            //Print pet's levels
            Console.WriteLine($"Pet's clean level:{UIMain.CurrentPet.GetCleanLevel()}"); /////////////////
            Console.WriteLine($"Pet's joy level:{UIMain.CurrentPet.GetJoyLevel()}"); //////////////
            Console.WriteLine("\n");

            Task<List<ActivityDTO>> t = UIMain.api.CleanlList();
            t.Wait();

            List<ActivityDTO> list = t.Result;
            //Print a table that contains the details we need to clean the pet
            List<Object> clean = (from cleanList in list
                                  where (cleanList.ActivityId >= 6 && cleanList.ActivityId <= 11)
                                  select new
                                  {
                                      ID = cleanList.ActivityId,
                                      Name = cleanList.ActivityName,
                                      CleanAdd = cleanList.CleanAdd,
                                      JoyAdd = cleanList.JoyAdd
                                  }).ToList<Object>();
            ObjectsList Cleanlist = new ObjectsList("Cleaning Options", clean);
            Cleanlist.Show();
            Console.WriteLine(" ");

            //Input activity id from the user
            Console.WriteLine("\nWould you like to clean your pet? (please enter yes/no)");
            string answer = Console.ReadLine();

            try
            {
                while(answer == "yes")
                {
                    Console.WriteLine("\nHow would you like to clean your pet? (please enter clean ID)");
                    int cleanNumber = int.Parse(Console.ReadLine());
                    //Check input
                    while (cleanNumber < FIRSTCLEAN || cleanNumber > LASTCLEAN)
                    {
                        Console.WriteLine("You entered an illogical number. \nPlease enter one of the numbers that are on the screen");
                        cleanNumber = int.Parse(Console.ReadLine());
                    }

                    //Clean the pet and add to pet's level
                    
                    Task<string> a = UIMain.api.UpdateClean(cleanNumber);
                    a.Wait();
                    Console.WriteLine($"{a.Result}\n");

                    Task<PlayerDTO> player = UIMain.api.GetPlayer();
                    player.Wait();
                    UIMain.CurrentPlayer = player.Result;

                    IEnumerable<PetDTO> petList = from p in UIMain.CurrentPlayer.Pets where (p.StatusId != DEAD) select p;
                    UIMain.CurrentPet = petList.FirstOrDefault();

                    Console.WriteLine("\nWould you like to clean your pet again? (please enter yes/no)");
                    answer = Console.ReadLine();

                }
                

                //Return to previous screen
                Console.WriteLine("\nPlease enter any key to go back");
                char ch = Console.ReadKey().KeyChar;
                if (ch != null)
                {
                    MainMenu m = new MainMenu();
                    m.Show();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine($"Fail with error: {e.Message}!");
            }
        }



    }
}
