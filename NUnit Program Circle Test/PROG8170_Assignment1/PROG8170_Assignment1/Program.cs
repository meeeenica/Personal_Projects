using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG8170_Assignment1
{
    class Program
    {
        private static bool endProg = false;
        private static double circRadius = 0;
        private static Circle newCircle = new Circle();
        static void Main(string[] args)
        {
            Console.Write("\nPlease enter value of  Radius: ");
            while (!double.TryParse(Console.ReadLine(), out circRadius) ||
            !(circRadius >= 0))
            {
                Console.WriteLine("\nInvalid input. Radius must be a numerical value and greater than or equal 0.");
                Console.Write("\nPlease enter value of  Radius: ");
            }
            newCircle.circleRadius = circRadius;
            while (endProg != true)
            {
                RunMenu();
            }
        }

        private static void RunMenu()
        {
            Console.Write("\nMenu:");
            Console.Write("\n--------------------------------------------");
            Console.Write("\n1 - Add to Circle Radius");
            Console.Write("\n2 - Subtract from Circle Radius");
            Console.Write("\n3 - Calculate Circle Circumference");
            Console.Write("\n4 - Calculate Circle Area");
            Console.Write("\n5 - Exit");
            Console.Write("\n\nEnter Option: ");
            int optionSelected = 0;
            while (!int.TryParse(Console.ReadLine(), out optionSelected))
            {
                Console.Write("\nInvalid input.");
                Console.Write("\n\nMenu:");
                Console.Write("\n--------------------------------------------");
                Console.Write("\n1 - Add to Circle Radius");
                Console.Write("\n2 - Subtract from Circle Radius");
                Console.Write("\n3 - Calculate Circle Circumference");
                Console.Write("\n4 - Calculate Circle Area");
                Console.Write("\n5 - Exit");
                Console.Write("\n\nEnter Option: ");
            }
            RunOption(optionSelected);
            Console.Write("\nPress any key to go back to main menu...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void RunOption(int option)
        {
            switch(option)
            {
                case 1: 
                    double addedValue = 0;
                    Console.Write("\nCurrent value of radius is: " + newCircle.circleRadius);
                    Console.Write("\nEnter value to be added to radius: ");
                    if (!double.TryParse(Console.ReadLine(), out addedValue) ||
                        !(addedValue >= 0))
                    {
                        Console.Write("\nInvalid input. Radius must be a numerical value and greater than 0.");
                    }
                    else
                    {
                        newCircle.AddToRadius(addedValue);
                        Console.Write("\nNew value of radius is: " + newCircle.circleRadius);
                    }
                    endProg = false;
                    break;
                case 2:
                    double lessValue = 0;
                    Console.Write("\nCurrent value of radius is: " + newCircle.circleRadius);
                    Console.Write("\nEnter value to be deducted from radius: ");
                    if (!double.TryParse(Console.ReadLine(), out lessValue) ||
                        !(lessValue >= 0) || lessValue > newCircle.circleRadius)
                    {
                        if (lessValue > newCircle.circleRadius)
                        {
                            Console.Write("\nValue to be subtracted must not be greater than Radius value.");
                        }
                        else
                        {
                            Console.Write("\nInvalid input. Radius must be a numerical value and greater than 0.");
                        }
                    }
                    else
                    {
                        newCircle.SubtractFromRadius(lessValue);
                        Console.Write("\nNew value of radius is: " + newCircle.circleRadius);
                    }
                    endProg = false;
                    break;
                case 3:
                    newCircle.GetCircumference();
                    Console.Write("\nCircumference of Circle is: " + newCircle.Circumference);
                    endProg = false;
                    break;
                case 4:
                    newCircle.GetArea();
                    Console.Write("\nArea of Circle is " + newCircle.Area);
                    endProg = false;
                    break;
                case 5: Environment.Exit(0);
                    endProg = true;
                    break;
                default:
                    Console.Write("\nInvalid input.");
                    break;
            }
        }
    }
}
