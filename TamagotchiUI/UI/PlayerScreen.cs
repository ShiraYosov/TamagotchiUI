using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TamagotchiUI.DTO;

namespace Tamagotchi.UI
{
    class PlayerScreen : Screen
    {
        public PlayerScreen() : base("Show Player")
        {

        }

        public override void Show()
        {
            base.Show();
            //Show the logged in player details
            ObjectView showPlayer = new ObjectView("", UIMain.CurrentPlayer);
            showPlayer.Show();
            Console.WriteLine("");
            Console.WriteLine("Press A to see your animals");
            Console.WriteLine("");
            Console.WriteLine("Press C to change your details");
            Console.WriteLine("");
            Console.WriteLine("Press any key to go back to menu");
            char c = Console.ReadKey().KeyChar;

            try
            {
                while (c == 'a' || c == 'A' || c == 'c' || c == 'C')
                {
                    if (c == 'a' || c == 'A')
                    {
                        Console.WriteLine();
                        //Show all player's pets details(alive and dead)
                        Task<List<PetDTO>> tt = UIMain.api.AnimalList();
                        tt.Wait();
                        List<PetDTO> lst = tt.Result;

                        List<Object> animals = (from animalList in lst
                                                select new
                                                {
                                                    ID = animalList.PetId,
                                                    Name = animalList.PetName,
                                                    BirthDate = animalList.BirthDate,
                                                    Status = animalList.GetStatus()
                                                }).ToList<Object>();
                        ObjectsList list = new ObjectsList("Animals", animals);
                        list.Show();
                        Console.WriteLine();
                    }
                    //Showing screen according to the pressed key

                    if (c == 'c' || c == 'C')
                    {
                        ChangeDetails change = new ChangeDetails();
                        change.Show();
                    }
                    c = Console.ReadKey().KeyChar;
                }
                Console.WriteLine("");

                //Returning to menu

                MainMenu m = new MainMenu();
                m.Show();

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong: {e.Message}!");
            }
        }
    }
}
