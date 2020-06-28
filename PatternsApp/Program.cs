using System;
using System.Threading;

namespace PatternsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Thread(() =>
            {
                Country Mexico = new Country();
                Mexico.Elect("Pedro");
                Console.WriteLine(Mexico.President.Name);
            })).Start();

            Country USA = new Country();
            USA.Elect("Trump");

            Console.WriteLine(USA.President.Name);

            #region
            //(new Thread(() =>
            //{
            //    Computer comp2 = new Computer();
            //    comp2.OS = OS.GetInstance("Windows 10");
            //    Console.WriteLine(comp2.OS.Name);
            //})).Start();

            //Computer comp = new Computer();
            //comp.Launch("Windows 8.1");
            //Console.WriteLine(comp.OS.Name);
            #endregion
        }
    }

    class Computer
    {
        public OS OS { get; set; }
        public void Launch(string osName)
        {
            OS = OS.GetInstance(osName);
        }
    }

    class OS
    {
        private static OS instance;
        public string Name { get; private set; }
        private static object syncRoot = new object();

        protected OS(string name) 
        {
            this.Name = name;
        }

        public static OS GetInstance(string name)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new OS(name);
                }
            }
                
            return instance;
        }
    }
}
