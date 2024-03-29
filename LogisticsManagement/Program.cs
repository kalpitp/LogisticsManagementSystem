﻿using Microsoft.Extensions.DependencyInjection;
using LogisticsManagement.UI;
using LogisticsManagement.Services.Interface;
using LogisticsManagement.Services.Service;
using LogisticsManagement.DataAccess.Repository;
using LogisticsManagement.DataAccess.Models;


namespace LogisticsManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<CybageLogisticsContext>()
                .AddSingleton<IAuthenticationServices, AuthenticationServices>()
                .AddSingleton<IAuthenticationRepository, AuthenticationRepository>()
                .BuildServiceProvider();

            var authService = serviceProvider.GetService<IAuthenticationServices>();


            while (true)
            {
                //Console.Clear();
                Console.WriteLine("--------------------------- Cybage Logistics ---------------------------");

                Console.WriteLine("\n1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");

                Console.WriteLine("\nPlease enter your choice: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Console.ResetColor();
                }
                
                AuthenticationMenu authMenu= new AuthenticationMenu();

                //CustomerMenu.ShowMenu();

                //ManagerMenu.ShowMenu();
                //DriverMenu.ShowMenu();
                //AdminMenu.ShowMenu();


                switch (choice)
                {
                    case 1:
                        authMenu?.Login(authService);
                        break;
                    case 2:
                        authMenu?.SignUp();
                        break;
                    case 3:
                        Console.WriteLine("Thank you for using Cybage Logistics!!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid choice!!");
                        Console.ResetColor();

                        break;
                }

            }
        }
    }
}
