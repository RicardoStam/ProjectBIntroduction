using ProjectBIntroduction.Server;
using ProjectBIntroduction.Server.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBIntroduction.FrontEnd
{
    internal class Client
    {
        private readonly ServerApi Api;

        public Client(ServerApi api)
        {
            Api = api;
        }

        public void Run()
        {
            while (true)
            {
                if(Introduction() == "c") CreateAccount();
                while (!Login()) { }
                Console.WriteLine("Time to implement the rest of the application!");
                break;
            }
        }

        private bool Login()
        {
            string username, password;
            bool loggedIn = false;
            while (true)
            {
                Console.WriteLine("Login");
                Console.WriteLine("Provide an username:");
                username = Console.ReadLine();
                Console.WriteLine("Provide a password:");
                password = Console.ReadLine();

                loggedIn = Api.AccountController().Login(username, password);

                if (!loggedIn) Console.WriteLine("Login failed.");
                else Console.WriteLine("Logged in!");

                return loggedIn;
            }
        }

        private void CreateAccount()
        {
            string username, password;

            while (true)
            {
                Console.WriteLine("Create an account");
                Console.WriteLine("Provide an username:");
                username = Console.ReadLine();
                Console.WriteLine("Provide a password:");
                password = Console.ReadLine();

                if (!Api.AccountController().Create(username, password))
                {
                    Console.WriteLine("The account could not be created.");
                    continue;
                }
                Console.WriteLine("Your account has been created.");
                return;
            }
        }

        private string Introduction()
        {
            string input;

            while (true)
            {
                Console.WriteLine("Hi, welcome to the reservation app!");
                Console.WriteLine("[c] - Create account, [l] - Login");
                input = Console.ReadLine().ToLower();
                if (input != "c" && input != "l") continue;
                else return input;
            }
        }
    }
}
