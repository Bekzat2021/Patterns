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
            Factory factory = new Factory();
            HondaFactory hondaBuilder = new HondaFactory();
            Car honda = factory.Build(hondaBuilder);
            Console.WriteLine(honda);
        }
    }

    class Engine
    {
        public string EngineInfo { get; set; }
    }

    class Conditioner
    {
        public bool ItHas { get; set; }
    }

    class Paint
    {
        public string Name { get; set; }
    }

    class Car
    {
        public Engine Engine { get; set; }
        public Conditioner Conditioner { get; set; }
        public Paint Paint { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: " + Name + "\n");
            sb.Append("Engine volume: " + Engine.EngineInfo + "\n");
            sb.Append("Conditioner: " + Conditioner.ItHas.ToString() + "\n");
            sb.Append("Color: " + Paint.Name + "\n");
            return sb.ToString();
        }
    }

    abstract class CarFactory
    {
        public Car Car { get; private set; }
        public CarFactory()
        {
            Car = new Car();
        }

        public abstract void SetEngine();
        public abstract void SetConditioner();
        public abstract void SetPaint();

        public abstract void SetName();
    }

    class HondaFactory : CarFactory
    {
        public override void SetName()
        {
            this.Car.Name = "Honda Civic";
        }

        public override void SetEngine()
        {
            this.Car.Engine = new Engine { EngineInfo = "1.8" };
        }

        public override void SetConditioner()
        {
            this.Car.Conditioner = new Conditioner { ItHas = true };
        }

        public override void SetPaint()
        {
            this.Car.Paint = new Paint { Name = "Red" };
        }
    }

    class Factory
    {
        public Car Build(CarFactory carFactory)
        {
            carFactory.SetName();
            carFactory.SetEngine();
            carFactory.SetConditioner();
            carFactory.SetPaint();
            return carFactory.Car;
        }
    }
}
