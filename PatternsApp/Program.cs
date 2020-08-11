using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatternsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BookStoreProxy proxy = new BookStoreProxy();
            Page page1 = proxy.GetPage(1);
            Console.WriteLine(page1.Text);

            Page page2 = proxy.GetPage(2);
            Console.WriteLine(page2.Text);

            page1 = proxy.GetPage(1);
            Console.WriteLine(page1.Text);
        }
    }

    class Page
    {
        public int Number { get; set; }
        public string Text { get; set; }
    }


    interface IBook 
    {
        Page GetPage(int number);
    }

    class BookStore : IBook
    {
        public Page GetPage(int number)
        {
            return new Page { Number = number, Text = $"Page {number} number with simple text" };
        }
    }

    class BookStoreProxy : IBook
    {
        List<Page> pages;
        BookStore BookStore;
        public BookStoreProxy()
        {
            pages = new List<Page>();
        }
        
        public Page GetPage(int number)
        {
            Page page = pages.FirstOrDefault(p => p.Number == number);
            if (page == null)
            {
                if (BookStore == null)
                {
                    BookStore = new BookStore();
                }
                page = BookStore.GetPage(number);
                pages.Add(page);
            }
            return page;
        }
    }
}
