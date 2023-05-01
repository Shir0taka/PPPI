using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Lab4
{
    internal class Program
    {
        public class Book
        {
            private string title;
            public int pages;
            protected char publisher;
            protected internal object author;
            internal float price;

            public Book(string title, int pages, char publisher, object author, float price)
            {
                this.title = title;
                this.pages = pages;
                this.publisher = publisher;
                this.author = author;
                this.price = price;
            }

            public string GetTitle()
            {
                return title;
            }

            public int GetPages()
            {
                return pages;
            }

            public char GetPublisher()
            {
                return publisher;
            }

            public object GetAuthor()
            {
                return author;
            }

            public float GetPrice()
            {
                return price;
            }
        }

        static void Main(string[] args)
        {
            Type type = typeof(Book);
            TypeInfo typeInfo = type.GetTypeInfo();

            Console.WriteLine($"Type title: {type.Name}");
            Console.WriteLine($"Type full title: {type.FullName}");
            Console.WriteLine($"Type info: {typeInfo}");

            MemberInfo[] members = type.GetMembers();
            Console.WriteLine("\nMemberInfo:");
            foreach (var member in members)
            {
                Console.WriteLine(" " + member.Name);
            }

            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("\nFieldInfo:");
            foreach (var field in fields)
            {
                Console.WriteLine(" " + field.Name);
            }

            object book = Activator.CreateInstance(type, new object[]
            {
                "At the Mountains of Madness",
                608,
                'I',
                "H. P. Lovecraft",
                12.63f
            });

            MethodInfo field1 = type.GetMethod("GetTitle");
            string title = (string)field1.Invoke(book, null);
            Console.WriteLine($"\nTitle: {title}");
            //
            MethodInfo field2 = type.GetMethod("GetPages");
            int pages = (int)field2.Invoke(book, null);
            Console.WriteLine($"Pages: {pages}");
            //
            MethodInfo field3 = type.GetMethod("GetPublisher");
            char publisher = (char)field3.Invoke(book, null);
            Console.WriteLine($"Publisher: {publisher}");
            //
            MethodInfo field4 = type.GetMethod("GetAuthor");
            object author = (object)field4.Invoke(book, null);
            Console.WriteLine($"Author: {author}");
            //
            MethodInfo field5 = type.GetMethod("GetPrice");
            float price = (float)field5.Invoke(book, null);
            Console.WriteLine($"Price: {price}$");

            Console.ReadKey();
        }
    }
}