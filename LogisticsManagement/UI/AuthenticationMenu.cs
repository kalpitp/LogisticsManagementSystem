using LogisticsManagement.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogisticsManagement.UI
{
    public class AuthenticationMenu
    {
       

        // For converting password to stars
        static string ReadPassword()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                // remove last character from password
                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                // on any key other than control characters add it to the password
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();
            return pass;
        }

        // Login
        public void Login(IAuthenticationServices _authService)
        {
            Console.Clear();
            Console.WriteLine("\n============ Sign In ============");
            Console.Write("Enter UserID: ");
            string? userId = Console.ReadLine();

            Console.Write("Enter Password: ");
            string? password = ReadPassword();

            Console.WriteLine("1. Login\n2. Back to Main Menu");
            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
            {                
                _authService.Login(userId, password);
                Console.WriteLine("Login successfull");
            }
            else if (option == 2)
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        // Signup
        public void SignUp()
        {
            Console.Clear();
            Console.WriteLine("\n============ Sign Up ============");
            Console.WriteLine("\nWant to sign Up as?");
            Console.WriteLine("1. Admin \n2. Customer\n3. Warehouse Manager\n4.Driver\n5.Back to Main Menu");
            Console.WriteLine("\nEnter your choice: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Admin");
                    break;
                case 2:
                    CustomerDetails();
                    break;
                case 3:
                    ManagerDetails();
                    break;
                case 4:
                    DriverDetails();
                    break;
                case 5:
                    return;
     
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }

        public void CommonDetails()
        {

            Console.Write("Enter Name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter Email: ");
            string? email = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string? phoneNumber = Console.ReadLine();

            Console.Write("Enter Password: ");
            string? password = ReadPassword();

            Console.Write("Enter Confirm Password:");
            string? confirmPassword = ReadPassword();
        }
        public void CustomerDetails()
        {
            CommonDetails();
            Console.Write("Enter Address: ");
            string? address = Console.ReadLine();

            //CustomerMenu customerMenu = new CustomerMenu();
            //customerMenu.ShowMenu();

        }
        public void ManagerDetails()
        {
            CommonDetails();
            Console.Write("Enter Warehouse Name: ");
            string? warehouseName = Console.ReadLine();
        }
        public void DriverDetails()
        {
            CommonDetails();
            Console.Write("Enter Licence Number: ");
            string? licenceNumber = Console.ReadLine();

            Console.Write("Vehicle Licence Type: ");
            string? vehicleType = Console.ReadLine();

            Console.Write("Enter Vehicle Number: ");
            string? vehicleNumber = Console.ReadLine();

        }

    }
}
