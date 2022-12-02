using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Principal;
using Lab_11;

namespace Lab_12
{
    class Program
    {
        static List<Book> SortBooksByName(List<Book> books)
        {
            return new List<Book>(collection: from book in books orderby book.Name select book);
        }
        static List<Book> SortBooksByAuthor(List<Book> books)
        {
            return new List<Book>(from book in books orderby book.Author select book);
        }
        static List<Book> SortBooksByPublisher(List<Book> books)
        {
            return new List<Book>(from book in books orderby book.Publisher select book);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 12.1");
            Account account1 = new Account(TypeAccount.Текущий, 300);
            Account account2 = new Account(TypeAccount.Сберегательный, 400);
            Console.WriteLine($"HashCode = {account1.GetHashCode()}");
            Console.WriteLine($"acc1 != acc2 ({account1.Equals(account2)})");
            Console.WriteLine($"acc1 == acc2 ({account1 == account2})");
            Console.WriteLine(account2);
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Задания 12.2-12.1 дз");
            Complex c1 = new Complex(10, 6);
            Complex c2 = new Complex(-55.4, 18);
            Complex c3 = new Complex(0,0);
            Console.WriteLine("c3 = c1 + c2 - c1 * c2;");
            c3 = c1 + c2 - c1 * c2;
            Console.WriteLine($"c3 = {c3}");
            Console.WriteLine($"c1 == c2 ({c1 == c2})");
            Console.WriteLine($"c1 == 10 + 6i ({c1.Equals(new Complex(10, 6))})");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Домашнее задание 12.2");
            BoxBook boxBook = new BoxBook(
                new Book(name: "sName", author: "CAuthor", publisher: "QPublisher"),
                new Book(name: "BName", author: "ZAuthor", publisher: "WPublisher"),
                new Book(name: "CName", author: "DAuthor", publisher: "EPublisher"),
                new Book(name: "kName", author: "EAuthor", publisher: "APublisher"),
                new Book(name: "FName", author: "OAuthor", publisher: "DPublisher"),
                new Book(name: "SName", author: "GAuthor", publisher: "HPublisher"),
                new Book(name: "EName", author: "JAuthor", publisher: "APublisher")
            );
            Console.WriteLine("Отсортированные книги по имени");
            foreach (var item in boxBook.GetSortedBooks(new BoxBook.DelegateSortingBook(SortBooksByName)))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Отсортированные книги по автору");
            foreach (var item in boxBook.GetSortedBooks(new BoxBook.DelegateSortingBook(SortBooksByAuthor)))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Отсортированные книги по издательству");
            foreach (var item in boxBook.GetSortedBooks(new BoxBook.DelegateSortingBook(SortBooksByPublisher)))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
        
    }
}