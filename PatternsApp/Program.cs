using System;
using System.Threading;

namespace PatternsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton = Singleton.GetInstance();
            Console.WriteLine(singleton.Name);

            Singleton singleton2 = Singleton.GetInstance();
            Console.WriteLine(singleton2.Name);
        }
    }

    class Singleton
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());
        public string Name { get; private set; }
        public Singleton()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static Singleton GetInstance()
        {
            return lazy.Value;
        }
    }
}
