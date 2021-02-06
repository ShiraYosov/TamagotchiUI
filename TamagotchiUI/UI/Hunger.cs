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

    class Hunger : Screen
    {
        const int FIRSTFOOD = 12;
        const int LASTFOOD = 24;
        const int DEAD = 1;
        public Hunger() : base("Feed Pet")
        {

        }

        public override void Show()
        {
            base.Show();

            //Print pet's levels
            Console.WriteLine($"Pet's hunger level:{UIMain.CurrentPet.GetHungerLevel()}");
            Console.WriteLine("\n");

            Task<List<FoodDTO>> t = UIMain.api.PrintFood();
            t.Wait();
            List<FoodDTO> p = t.Result;
            //Print a table that contains the details we need to feed the pet
            List<object> food = (from foodList in p
                                 select new
                                 {
                                     ID = foodList.FoodId,
                                     Name = foodList.ActivityName,
                                     SatiatyLevel = foodList.SatiatyLevel,
                                     Calories = foodList.Calories,
                                     cleanAdd = foodList.CleanAdd,
                                     joyAdd = foodList.JoyAdd
                                 }).ToList<Object>();
            ObjectsList list = new ObjectsList("Feeding Options", food);
            list.Show();
            Console.WriteLine(" ");

            //Input food id from the user
            Console.WriteLine("\nWould you like to feed your pet? (please enter yes/no)");
            string answer = Console.ReadLine();

            try
            {

                while (answer == "yes")
                {
                    Console.WriteLine("\nHow would you like to feed your pet? (please enter food ID)");
                    int foodNumber = int.Parse(Console.ReadLine());
                    while (foodNumber < FIRSTFOOD || foodNumber > LASTFOOD)
                    {
                        Console.WriteLine("You entered an illogical number. \nPlease enter one of the numbers that are on the screen");
                        foodNumber = int.Parse(Console.ReadLine());
                    }

                    Task<string> a = UIMain.api.Feed(foodNumber);
                    a.Wait();
                    Console.WriteLine($"{a.Result}\n");

                    Task<PlayerDTO> player = UIMain.api.GetPlayer();
                    player.Wait();
                    UIMain.CurrentPlayer = player.Result;

                    IEnumerable<PetDTO> petList = from pet in UIMain.CurrentPlayer.Pets where (pet.StatusId != DEAD) select pet;
                    UIMain.CurrentPet = petList.FirstOrDefault();

                    Console.WriteLine("\nWould you like to feed your pet again? (please enter yes/no)");
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

