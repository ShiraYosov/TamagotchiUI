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
//    class Clean : Screen
//    {
//        const int FIRSTCLEAN = 6;
//        const int LASTCLEAN = 11;
//        public Clean() : base("Clean Pet")
//        {

//        }

//        public override void Show()
//        {
//            base.Show();

//            //Print pet's levels
//            Console.WriteLine($"Pet's clean level:{UIMain.CurrentPlayer.Pet.Clean.CleanLevel}");
//            Console.WriteLine($"Pet's joy level:{UIMain.CurrentPlayer.Pet.Joy.Feelings}");
//            Console.WriteLine("\n");

//            //Print a table that contains the details we need to clean the pet
//            List<Object> clean = (from cleanList in UIMain.db.Activities where (cleanList.ActivityId >= 6 && cleanList.ActivityId <= 11)
//                                  select new
//                                  {
//                                      ID = cleanList.ActivityId,
//                                      Name = cleanList.ActivityName,
//                                      CleanAdd = cleanList.CleanAdd,
//                                      JoyAdd = cleanList.JoyAdd
//                                  }).ToList<Object>();
//            ObjectsList list = new ObjectsList("Cleaning Options", clean);
//            list.Show();
//            Console.WriteLine(" ");

//            //Input activity id from the user
//            Console.WriteLine("\nHow would you like to clean your pet?");
//            int cleanNumber = int.Parse(Console.ReadLine());
            

//            try
//            {
//                //Check input
//                while (cleanNumber < FIRSTCLEAN || cleanNumber > LASTCLEAN)
//                {                   
//                    Console.WriteLine("You entered an illogical number. \nPlease enter one of the numbers that are on the screen");
//                    cleanNumber = int.Parse(Console.ReadLine());
//                }

//                //Clean the pet and add to pet's level
//                Activity a = UIMain.db.Activities.Where(n => n.ActivityId == cleanNumber).FirstOrDefault();
//                UIMain.CurrentPlayer.Pet.Cleaning( a, UIMain.db);
//                Console.WriteLine("");

//                //Return to previous screen
//                Console.WriteLine("\nPlease enter any key to go back");
//                char ch = Console.ReadKey().KeyChar;
//                if (ch != null)
//                {
//                    AnimalMeasures b = new AnimalMeasures();
//                    b.Show();
//                }
//            }

//            catch (Exception e)
//            {
//                Console.WriteLine($"Fail with error: {e.Message}!");
//            }
//        }
//    }
//}