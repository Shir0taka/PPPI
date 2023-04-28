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
    //Email Sender API
    public class EmailSender
    {
        public void SendEmail(string from, string to, string subject, string body)
        {
            MailMessage mail = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential("your_email@gmail.com", "your_password");
            client.EnableSsl = true;
            client.Send(mail);
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

        public void WriteToFile(string path, string text)
        {
            File.WriteAllText(path, text);
        }
    }
    //Weather API
    public class WeatherAPI
    {
        private const string API_KEY = "42093ba7-121f-4220-8868-c364e03d085e";
        private const string BASE_URL = "http://api.openweathermap.org/data/2.5/weather?q=";

        public Weather GetWeather(string city)
        {
            using (var client = new HttpClient())
            {
                string url = BASE_URL + city + "&appid=" + API_KEY;
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    Weather weather = JsonConvert.DeserializeObject<Weather>(json);
                    return weather;
                }
                else
                {
                    return null;
                }
            }
        }
    }
    
    public class Weather
    {
        public string Name { get; set; }
        public Main Main { get; set; }
    }

    public class Main
    {
        public float Temp { get; set; }
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

            return a;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Choose API:\n" +
                    "1. Random API\n" +
                    "2. Email sender API\n" +
                    "3. File system API\n" +
                    "4. Weather API\n" +
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
                        Console.Clear();
                        Console.WriteLine($"Result: {rnd.GenRndNum(first, second)} \n");
                        break;
                    case 2:

                    case 3:

                    case 4:

                    case 5:

                    default:
                        Console.WriteLine("Incorrect input!");
                        break;
                }
            }
        }
    }
}