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

    class ChangeDetails : Screen
    {
        

        public ChangeDetails() : base("Change Details")
        {
           
        }

        public override void Show()
        {
            base.Show();

            Console.WriteLine("If you want to:\nChange password- press 1\nChange username- press 2\nChange mail- press 3");
            char c = Console.ReadKey().KeyChar;
            PlayerDTO CurrentPlayer = UIMain.CurrentPlayer;

            //Choosing the change type according to the pressed key 
            if (c == '1')
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Please type new password: ");

                    //Changing password
                    string newPswd = Console.ReadLine();
                    if (newPswd != "")
                    {
                       Task<string> t = UIMain.api.ChangePass(newPswd);
                        t.Wait();
                        Console.WriteLine(t.Result);
                    }
                    else
                        Console.WriteLine("Password not changed! new value was not written");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Password change fail with error: {e.Message}!");
                }

            }

            if (c == '2')
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Please Type new username: ");

                    //Changing username
                    string newName = Console.ReadLine();
                    if (newName != "")
                    {
                        Task<string> a = UIMain.api.ChangeUserName(newName);
                        a.Wait();
                        Console.WriteLine(a.Result);
                    }
                      
                    else
                        Console.WriteLine("Username not changed! new value was not written");
                    Console.ReadKey();
                }

                catch (Exception e)
                {
                    Console.WriteLine($"Username change fail with error: {e.Message}!");
                }

            }

            if (c == '3')
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Please Type new mail: ");

                    //Changing mail
                    string newMail = Console.ReadLine();
                    if (newMail != "")
                    {
                        Task<string> f = UIMain.api.ChangeEmail(newMail);
                        f.Wait();
                        Console.WriteLine(f.Result);
                    }
                      
                    else
                        Console.WriteLine("Mail not changed! new value was not written");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Email change fail with error: {e.Message}!");
                }

            }



        }
    }
}
