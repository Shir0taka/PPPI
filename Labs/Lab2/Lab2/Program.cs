using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.ExceptionServices;
using System.Diagnostics;
using Microsoft.SqlServer.Server;

namespace Lab2
{
    //Random API
    public class RndNumGen
    {
        private Random _random;

        public RndNumGen()
        {
            _random = new Random();
        }

        public int GenRndNum(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
    //Time API
    public class Time
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }

        public DateTime AddTime(DateTime time, TimeSpan duration)
        {
            return time.Add(duration);
        }

        public TimeSpan GetDuration(DateTime start, DateTime end)
        {
            return end - start;
        }
    }
    //File System API
    public class FileSystem
    {
        public void CreateDir(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void WriteToFile(string name, string text)
        {
            File.WriteAllText(name, text);
        }
    }
    //String Manipulation API
    public class StringRofls
    {
        public string Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public string Concatenate(string str1, string str2)
        {
            return str1 + str2;
        }
    }
    //Calculator API
    public class Calc
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }

            return a / b;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Choose API:\n" +
                    "1. Random API\n" +
                    "2. Time API\n" +
                    "3. File system API\n" +
                    "4. String Manipulation API\n" +
                    "5. Calculator API\n" +
                    "0. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        RndNumGen rnd = new RndNumGen();

                        Console.WriteLine("Enter min num: ");
                        int first = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter max num: ");
                        int second = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Result: {rnd.GenRndNum(first, second)} \n");

                        Console.WriteLine("Press 'Enter' to continue");
                        cki = Console.ReadKey();
                        if(cki.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                        }
                        break;
                    case 2:
                        Time time = new Time();
                        Console.WriteLine($"Current date is {time.GetCurrentDate()} \n");

                        Console.WriteLine("Set duration: ");
                        DateTime start = DateTime.Parse(Console.ReadLine());
                        DateTime end = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine($"This duration is {time.GetDuration(start, end)} \n");

                        Console.WriteLine("Set time: ");
                        DateTime new_Time = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Set duration days: ");
                        TimeSpan dur = TimeSpan.Parse(Console.ReadLine());
                        Console.WriteLine($"Time {time.AddTime(new_Time, dur)} added \n");

                        Console.WriteLine("Press 'Enter' to continue");
                        cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter path to create a directory: ");
                        string file_path = Console.ReadLine();
                        if (file_path == "skip")
                        { }else
                        {
                            FileSystem path = new FileSystem();
                            path.CreateDir(file_path);
                            Console.WriteLine($"Directory \"{file_path}\" successfully created!");
                        }

                        FileSystem file = new FileSystem();
                        Console.WriteLine("Enter name file: ");
                        string file_name = Console.ReadLine();

                        Console.WriteLine("What write in the file?: ");
                        string text = Console.ReadLine();
                        file.WriteToFile(file_name, text);
                        Console.WriteLine($"File {file_name} created/redacted!\n");

                        Console.WriteLine("Press 'Enter' to continue");
                        cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                        }
                        break;
                    case 4:
                        StringRofls rofl = new StringRofls();

                        Console.WriteLine("Enter you line: ");
                        string my_Line = Console.ReadLine();
                        Console.WriteLine($"Reversed line: {rofl.Reverse(my_Line)} \n");

                        Console.WriteLine("Enter first part: ");
                        string part_First = Console.ReadLine();
                        Console.WriteLine("Enter second part: ");
                        string part_Second = Console.ReadLine();
                        Console.WriteLine($"Concatenation result: {rofl.Concatenate(part_First, part_Second)} \n");

                        Console.WriteLine("Press 'Enter' to continue");
                        cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                        }
                        break;
                    case 5:
                        Calc math = new Calc();

                        Console.WriteLine("Enter numbers: ");
                        int a = int.Parse(Console.ReadLine());
                        int b = int.Parse(Console.ReadLine());

                        Console.WriteLine("Choose operation: ");
                        char oper = Console.ReadLine()[0];

                        switch (oper)
                        {
                            case '+':
                                Console.WriteLine($"Result: {math.Add(a, b)} \n");
                                break;
                            case '-':
                                Console.WriteLine($"Result: {math.Subtract(a, b)} \n");
                                break;
                            case '*':
                                Console.WriteLine($"Result: {math.Multiply(a, b)} \n");
                                break;
                            case '/':
                                Console.WriteLine($"Result: {math.Divide(a, b)} \n");
                                break;
                        }

                        Console.WriteLine("Press 'Enter' to continue");
                        cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                        }
                        break;
                    default:
                        Console.WriteLine("Incorrect input!");
                        break;
                }
            }
        }
    }
}