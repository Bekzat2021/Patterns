using System;
using System.Collections.Generic;
using System.IO;
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
            //Library library = new Library();
            //Reader reader = new Reader();
            //reader.SeeBooks(library);

            Week week = new Week();
            User user = new User();
            user.SeeWeek(week);

            Library library = new Library();
            Reader reader = new Reader();
            reader.SeeBooks(library);
        }
    }

    class Reader
    {
        public void SeeBooks(IBookNumerable iterator)
        {
            var libraryIterator = iterator.CreateIterator();
            while (libraryIterator.HasNext())
            {
                Book book = libraryIterator.Next();
                Console.WriteLine(book.Name);
            }
        }
    }

    interface IBookIterator
    {
        bool HasNext();
        Book Next();
    }

    interface IBookNumerable
    {
        int Count { get; }
        Book this[int index] { get; }
        IBookIterator CreateIterator();
    }

    class Book
    {
        public string Name { get; set; }
    }

    class Library : IBookNumerable
    {
        Book[] books;
        public Library()
        {
            books = new Book[]{
                new Book { Name = "Book one" },
                new Book { Name = "Book two" },
                new Book { Name = "Book three" },
                new Book { Name = "Book four" }
            };
        }

        public Book this[int index] => books[index];

        public int Count => books.Length;

        public IBookIterator CreateIterator()
        {
            return new LibraryIterator(this);
        }
    }

    class LibraryIterator : IBookIterator
    {
        private IBookNumerable numerable;
        int index = 0;
        public LibraryIterator(IBookNumerable numerable)
        {
            this.numerable = numerable;
        }
        public bool HasNext()
        {
            return index < numerable.Count;
        }

        public Book Next()
        {
            return numerable[index++];
        }
    }

    #region 
    class User
    {
        public void SeeWeek(Week week)
        {
            IDayIterator iterator = week.CreateIterator();
            while (iterator.HasNext())
            {
                Day day = iterator.Next();
                Console.WriteLine(day.Name);
            }
        }
    }

    class Day
    {
        public string Name { get; set; }
    }

    interface IDayIterator
    {
        bool HasNext();
        Day Next();
    }

    interface IDayNumerable
    {
        IDayIterator CreateIterator();
        int Count { get; }
        Day this[int index] { get; } //индексатор
    }

    class Week : IDayNumerable
    {
        Day[] days;
        public Week()
        {
            days = new Day[]{ new Day { Name = "Monday" },
                new Day { Name = "Tuesday" },
                new Day { Name = "Wednesday" },
                new Day { Name = "Thursday" },
                new Day { Name = "Friday" },
                new Day { Name = "Saturday" },
                new Day { Name = "Sunday" }};
        }

        public Day this[int index] => days[index];

        public int Count => days.Length;

        public IDayIterator CreateIterator()
        {
            return new WeekIterator(this);
        }
    }

    class WeekIterator : IDayIterator
    {
        IDayNumerable numerable;
        int index = 0;
        public WeekIterator(IDayNumerable n)
        {
            numerable = n;
        }

        public bool HasNext()
        {
            return index < numerable.Count;
        }

        public Day Next()
        {
            return numerable[index++];
        }
    }

    #endregion

    //класс читателя *************************************************************
    //class Reader
    //{
    //    public void SeeBooks(Library library)
    //    {
    //        IBookIterator iterator = library.CreateNumerator();
    //        while (iterator.HasNext())
    //        {
    //            Book book = iterator.Next();
    //            Console.WriteLine(book.Name);
    //        }
    //    }
    //}
    ////класс книги с свойством имени
    //class Book
    //{
    //    public string Name { get; set; }
    //}
    ////итератор 
    //interface IBookIterator
    //{
    //    bool HasNext();
    //    Book Next();
    //}

    //interface IBookNumerable
    //{
    //    IBookIterator CreateNumerator();
    //    int Count { get; }
    //    Book this[int index] { get; }
    //}

    //class Library : IBookNumerable
    //{
    //    private Book[] books;
    //    public Library()
    //    {
    //        books = new Book[]
    //        {
    //            new Book{ Name = "Война и мир" },
    //            new Book { Name = "Отцы и дети" },
    //            new Book { Name = "Вишневый сад" }
    //        };
    //    }

    //    public int Count
    //    {
    //        get { return books.Length; }
    //    }

    //    public Book this[int index]
    //    {
    //        get { return books[index]; }
    //    }

    //    public IBookIterator CreateNumerator()
    //    {
    //        return new LibraryNumertor(this);
    //    }
    //}

    //class LibraryNumertor : IBookIterator
    //{
    //    IBookNumerable aggregate;
    //    int index = 0;
    //    public LibraryNumertor(IBookNumerable a)
    //    {
    //        aggregate = a;
    //    }
    //    public bool HasNext()
    //    {
    //        return index < aggregate.Count;
    //    }

    //    public Book Next()
    //    {
    //        return aggregate[index++];
    //    }
    //}
}
