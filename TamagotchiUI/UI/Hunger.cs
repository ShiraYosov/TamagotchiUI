//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.VisualBasic.CompilerServices;
//using TamagotchiUI.WebServices;
//using System.Threading.Tasks;
//using TamagotchiUI.DTO;

//namespace Tamagotchi.UI
//{

//    class Hunger : Screen
//    {
//        const int FIRSTFOOD = 12;
//        const int LASTFOOD = 24;
//        public Hunger() : base("Feed Pet")
//        {

//        }

//        public override void Show()
//        {
//            base.Show();
            
//            //Print pet's levels
//            Console.WriteLine($"Pet's hunger level:{UIMain.CurrentPlayer.Pet.Hunger.HungerLevel}");
//            Console.WriteLine("\n");

//            //Print a table that contains the details we need to feed the pet
//            List<Object> food = (from foodList in UIMain.db.Foods 
//                                 select new
//                                 {
//                                     ID = foodList.FoodId,
//                                     Name = foodList.FoodNavigation.ActivityName,
//                                     SatiatyLevel = foodList.SatiatyLevel,
//                                     Calories = foodList.Calories,
//                                     //cleanAdd = UIMain.db.Activities.Where(p => p.ActivityId == foodList.FoodId).Select(p1 => p1.CleanAdd),
//                                     //joyAdd = UIMain.db.Activities.Where(p => p.ActivityId == foodList.FoodId).Select(p1 => p1.JoyAdd)
//                                 }).ToList<Object>();
//            ObjectsList list = new ObjectsList("Feeding Options", food);
//            list.Show();
//            Console.WriteLine(" ");

//            //Input food id from the user
//            Console.WriteLine("\nHow would you like to feed your pet(please enter food ID)?");
//            int foodNumber = int.Parse(Console.ReadLine());

//            try
//            {
//                //Check input
//                while (foodNumber < FIRSTFOOD || foodNumber > LASTFOOD)
//                {
//                    Console.WriteLine("You entered an illogical number. \nPlease enter one of the numbers that are on the screen");
//                    foodNumber = int.Parse(Console.ReadLine());
//                }

//                //Feed the pet and add to pet's level
//                Food f = UIMain.db.Foods.Where(n => n.FoodId == foodNumber).FirstOrDefault();
//                UIMain.CurrentPlayer.Pet.Feed( f , UIMain.db);
//                Console.WriteLine("");

//                //Return to previous screen
//                Console.WriteLine("\nPlease enter any key to go back");
//                char ch = Console.ReadKey().KeyChar;
//                if (ch != null)
//                {
//                    AnimalMeasures c = new AnimalMeasures();
//                    c.Show();
//                }

//            }
            
//            catch (Exception e)
//            {
//                Console.WriteLine($"Fail with error: {e.Message}!");
//            }




//        }
//    }







//}
        
