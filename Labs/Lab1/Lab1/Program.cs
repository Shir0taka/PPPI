using System;
using System.IO;
using System.Linq;

namespace Lab1
{
    class Program
    {
        static void ShowWordsInText()
        {
            string pathFile = "lorem_ipsum.txt";
            string text = File.ReadAllText(pathFile);
            int showWords = int.Parse(Console.ReadLine());

            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r' });
            Console.WriteLine($"Result: {string.Join(" ", words.Take(showWords))} \n");
        }

        static void DoMath()
        {
            //values
            Console.Write("Enter first value: ");
            double num1 = double.Parse(Console.ReadLine());
            Console.Write("Enter second value: ");
            double num2 = double.Parse(Console.ReadLine());
            //operation
            Console.Write("Select operation (+, -, *, /): ");
            char operation = Console.ReadLine()[0];
            //Math
            double res = 0;
            switch (operation)
            {
                case '+':
                    res = num1 + num2;
                    Console.WriteLine($"Result: {res} \n");
                    break;
                case '-':
                    res = num1 - num2;
                    Console.WriteLine($"Result: {res} \n");
                    break;
                case '*':
                    res = num1 * num2;
                    Console.WriteLine($"Result: {res} \n");
                    break;
                case '/':
                    res = num1 / num2;
                    Console.WriteLine($"Result: {res} \n");
                    break;
                default:
                    Console.WriteLine("Incorrect operation! \n");
                    return;
            }
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            //exit bool
            bool exit = false;

            while (!exit)
            {
                //Menu
                Console.WriteLine("Choose option:");
                Console.WriteLine("1. Set amount of words to show");
                Console.WriteLine("2. Do math operations");
                Console.WriteLine("0. Exit");

                //User input
                int choice = int.Parse(Console.ReadLine());

                //choices
                switch (choice)
                {
                    case 1:
                        //func 1
                        Console.WriteLine("Enter a number words:");
                        ShowWordsInText();

                        Console.WriteLine("Press 'Enter' to continue");
                        cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                        }
                        break;
                    case 2:
                        //func 2
                        DoMath();

                        Console.WriteLine("Press 'Enter' to continue");
                        cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                        }
                        break;
                    case 0:
                        //exit
                        exit = true;
                        break;
                    default:
                        //error
                        Console.WriteLine("Incorrect input!");
                        break;
                }
            }
        }
    }
}
