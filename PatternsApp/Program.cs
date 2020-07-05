using System;
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
            Navigator navigator = new Navigator("аэропорт", "дом", new Walk());
            navigator.Move();

            navigator.MoveType = new onCar();
            navigator.Move();

            navigator.MoveType = new OnBus();
            navigator.Move();
        }
    }

    interface IMove
    {
        void Move();
    }

    class Walk : IMove
    {
        public void Move()
        {
            Console.WriteLine("пешком");
        }
    }

    class onCar : IMove
    {
        public void Move()
        {
            Console.WriteLine("на автомобиле");
        }
    }

    class OnBus : IMove
    {
        public void Move()
        {
            Console.WriteLine("на автобусе");
        }
    }

    class Navigator
    {
        public string Start { get; set; }
        public string Finish { get; set; }
        public IMove MoveType { get; set; }
        public Navigator(string start, string finish, IMove moveType)
        {
            Start = start;
            Finish = finish;
            MoveType = moveType;
        }

        public void Move()
        {
            Console.Write($"Вы перемещаетесть из {Start} в {Finish} ");
            MoveType.Move();
        }
    }
}
