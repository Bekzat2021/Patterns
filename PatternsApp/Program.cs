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
            Library library = new Library();
            Reader reader = new Reader();
            reader.SeeBooks(library);

            Week days = new Week();
            User user = new User();
            user.SeeDays();
        }
    }

    interface IDaysIterator
    {
        bool HasNext();
        Day Next();
    }

    interface IDaysEnumerable
    {
        Day this[int index] { get; }
        int Count { get; }
        IDaysIterator CreateNumerator();
    }

    class Day
    {
        public string Name { get; set; }
    }

    class Week
    {
        Day[] days;
        public Week()
        {
            //days = Закончить
        }
    }
}
