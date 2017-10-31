using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_Deliverable7_Lab7_StudentInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Build the database
            string[] arrNames     = { "Liam Boll", "Jacob Snover", "Jason Kubo", "Beni Rajanish", "Jordan Contreras", "Dave Ryda", "Evan Ricard", "Mike McCarthy", "Dave Schwartz", "Stephen Scobie", "Pierce Lauring", "Peter Guenther", "Z.Z. Zuzz" };
            string[] arrFoods     = { "hamburgers", "hot dogs", "hummus", "asparagus", "french fries", "sushi", "broccoli", "pumpkin pie", "pizza", "gnocchi", "sauerkraut", "tacos", "green eggs and ham" };
            string[] arrHometowns = { "Grosse Pointe, MI", "Chicagoland, IL-IN", "Traverse City, MI", "Livonia, MI", "Ferndale, MI", "Detroit, MI", "Bay City, MI", "Detroit, MI", "West Bloomfield, MI", "Kalamazoo, MI", "Bloomfield Hills, MI", "Escanaba, MI", "Whoville" };

            Console.WriteLine("/*************************/");
            Console.WriteLine("/* Student Database v1.0 */");
            Console.WriteLine("/*************************/");

            //initialize student record selector
            int recNo = 0;

            //main loop through program that checks if the user wants to continue or not. exits out if invalid data is given more than five times.
            bool continueStatus = true;
            while (continueStatus)
            {
                Console.Write("Would you like to learn more about a particular student here at Grand Circus? (Type 'Y' to continue): ");
                if (Console.ReadLine().ToUpper() != "Y")
                {
                    continueStatus = false;
                }
                else if (!validateDbRecordNum(arrNames, ref recNo)) //checks for excessive, invalid entries
                {
                    Console.WriteLine("After five, unsuccessful attempts the program is no longer able to continue and will close.");
                    continueStatus = false;
                }
                else
                {
                    Console.WriteLine($"Student {recNo} is {arrNames[recNo - 1]}. What would you like to know about {arrNames[recNo - 1].Split(' ')[0]}?");

                    Console.Write("Enter \"hometown\" or \"favorite food\": ");
                    string fieldSelection = Console.ReadLine().ToLower().Trim();

                    if (string.IsNullOrEmpty(validateDbField(ref fieldSelection)))
                    {
                        Console.WriteLine("Query attempt limit reached. Perhaps you are interested in another student.");
                        continueStatus = true;
                    }
                    else if (fieldSelection == "hometown")
                    {
                        Console.Write($"{arrNames[recNo - 1]} is from {arrHometowns[recNo - 1]}. Would you like to know more? (enter yes or no): ");
                        if (Console.ReadLine().ToLower() == "yes")
                        {
                            Console.WriteLine($"{arrNames[recNo - 1].Split(' ')[0]}\'s favorite food is {arrFoods[recNo - 1]}.");
                            Console.WriteLine();
                            continueStatus = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            continueStatus = true;
                        }
                    }
                    else
                    {
                        Console.Write($"{arrNames[recNo - 1].Split(' ')[0]}\'s favorite food is {arrFoods[recNo - 1]}. Would you like to know more? (enter yes or no): ");
                        if (Console.ReadLine().ToLower() == "yes")
                        {
                            Console.WriteLine($"{arrNames[recNo - 1]} is from {arrHometowns[recNo - 1]}.");
                            Console.WriteLine();
                            continueStatus = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            continueStatus = true;
                        }
                    }
                }

            }
            Console.WriteLine();
            Console.WriteLine("Sorry to see you go. Come back soon!");
        }

        public static bool validateDbRecordNum (string[] arr, ref int recNo)
        {
            int attempts = 0;

            Console.Write("Please enter in a number (1 - 12) to learn more about that student: ");
            bool valid = int.TryParse(Console.ReadLine(), out recNo);

            while (attempts < 4)
            {
                if (!valid || recNo > arr.Length)
                {
                    Console.WriteLine("That was not a valid entry. Please try again ({0} attempts left)", 4 - attempts);
                    Console.Write("Please enter in a student number (1 - 12): ");
                    valid = int.TryParse(Console.ReadLine(), out recNo);
                    Console.WriteLine();
                    attempts++;
                }
                else
                {
                    break;
                }
            }

            if (attempts >= 4 && (!valid || recNo > arr.Length))
            {
                //attempt limit reached without valid input
                return false;
            }
            else
            {
                //record number given for query is legit
                return true;
            }
        }

        public static string validateDbField (ref string field)
        {
            int attempts = 0;

            while (attempts < 4)
            {
                if (field != "hometown" && field != "favorite food")
                {
                    Console.WriteLine("That was not a valid entry. Please try again ({0} attempts left)", 4 - attempts);
                    Console.Write("Enter \"hometown\" or \"favorite food\": ");
                    field = Console.ReadLine();
                    Console.WriteLine();
                    attempts++;
                }
                else
                {
                    break;
                }
            }

            if (attempts >= 4 && (field != "hometown" && field != "favorite food"))
            {
                //attempt limit reached without valid field selection
                return "";
            }
            else
            {
                //field selection input for query is legit
                return field;
            }
        }
    }
}
