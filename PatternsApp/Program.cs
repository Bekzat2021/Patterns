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
            Cake redCake = new RedCake("Red cake");
            redCake = new CakeWithStrawberry(" strawberry ", redCake);
            redCake = new CakeWithNuts(" nuts ", redCake);
            redCake.CakeInfo();
        }
    }

    abstract class Cake
    {
        public string Name { get; set; }
        public Cake(string name)
        {
            Name = name;
        }
        public abstract void CakeInfo();
    }


    internal class RedCake : Cake
    {
        public RedCake(string name) : base(name) { }
        public override void CakeInfo()
        {
            Console.Write("Red Cake");
        }
    }

    internal abstract class CakeDecorator : Cake
    {
        protected Cake cake;
        public CakeDecorator(string name, Cake cake) : base(name)
        {
            this.cake = cake;
        }
    }

    class CakeWithStrawberry : CakeDecorator
    {
        public CakeWithStrawberry(string name, Cake cake) : base(name + " with strawberry", cake)
        {
            this.cake = cake;
        }
        public override void CakeInfo()
        {
            cake.CakeInfo();
            Console.Write(" with strawberry");
        }
    }


    class CakeWithNuts : CakeDecorator
    {
        public CakeWithNuts(string name, Cake cake) : base(name + " with nuts ", cake)
        {

        }
        public override void CakeInfo()
        {
            cake.CakeInfo();
            Console.Write(" with many nuts");
        }
    }
}
