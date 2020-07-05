using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;


namespace PatternsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stock stock = new Stock();
            //Bank bank = new Bank("Unity bank", stock);
            //Broker broker = new Broker("John SMith", stock);

            //stock.Market();
            //broker.StopTrade();
            //Console.WriteLine();

            //stock.Market();

            Engineer engineer = new Engineer();
            Viewer smith = new Viewer();
            Viewer bob = new Viewer();

            engineer.RegisterViewer(smith);
            engineer.RegisterViewer(bob);
            engineer.Make(false);
        }
    }

    interface IEngineer
    {
        void RegisterViewer(IViewer viewer);
        void RemoveViewer(IViewer viewer);
        void NotifyViewers(bool cool);
    }

    interface IViewer
    {
        void Update(bool cool);
    }

    class Engineer : IEngineer
    {
        List<IViewer> viewers;
        public Engineer()
        {
            viewers = new List<IViewer>();
        }
        public void NotifyViewers(bool cool)
        {
            foreach (var item in viewers)
            {
                item.Update(cool);
            }
        }

        public void RegisterViewer(IViewer viewer)
        {
            viewers.Add(viewer);
        }

        public void RemoveViewer(IViewer viewer)
        {
            viewers.Remove(viewer);
        }

        public void Make(bool cool)
        {
            NotifyViewers(cool);
        }
    }

    class Viewer : IViewer
    {
        public void Update(bool cool)
        {
            if (cool)
                Console.WriteLine("Engineer make something cool");
            else
                Console.WriteLine("Engineer make something NOT cool");
        }
    }

    #region
    interface IObserver
    {
        void Update(Object obj);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    class Stock : IObservable
    {
        StockInfo sInfo;
        List<IObserver> observers;

        public Stock()
        {
            observers = new List<IObserver>();
            sInfo = new StockInfo();
        }

        public void Market()
        {
            Random rnd = new Random();
            sInfo.USD = rnd.Next(20, 40);
            sInfo.Euro = rnd.Next(30, 50);
            NotifyObservers();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(sInfo);
            }
        }
    }

    class Broker : IObserver
    {
        public string Name { get; set; }
        IObservable stock;

        public Broker(string name, IObservable observable)
        {
            Name = name;
            stock = observable;
            stock.RegisterObserver(this);
        }


        public void Update(object obj)
        {
            StockInfo sInfo = (StockInfo)obj;

            if(sInfo.USD > 30)
                Console.WriteLine($"Брокер {Name} продает доллары;  Курс доллара: {sInfo.USD}");
            else
                Console.WriteLine($"Брокер {Name} покупает доллары;  Курс доллара: {sInfo.USD}");
        }

        public void StopTrade()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }

    class Bank : IObserver
    {
        public string Name { get; set; }
        IObservable stock;
        public Bank(string name, IObservable stock)
        {
            Name = name;
            this.stock = stock;
            stock.RegisterObserver(this);
        }
        public void Update(object obj)
        {
            StockInfo sInfo = (StockInfo)obj;

            if(sInfo.Euro > 40)
                Console.WriteLine($"Банк {Name} продает евро;  Курс евро: {sInfo.Euro}");
            else
                Console.WriteLine($"Банк {Name} покупает евро;  Курс евро: {sInfo.Euro}");
        }
    }

    class StockInfo
    {
        public int USD { get; set; }
        public int Euro { get; set; }
    }
    #endregion
}
