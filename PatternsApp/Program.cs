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
            Water water = new Water(new LiquidState());
            water.Heat();
            water.Heat();

            water.Froze();
            water.Froze();
            water.Froze();
        }
    }

    interface IWaterState
    {
        void Heat(Water water);
        void Froze(Water water);
    }

    class SolidState : IWaterState
    {
        public void Froze(Water water)
        {
            Console.WriteLine("Продолжаем заморозку льда");
        }

        public void Heat(Water water)
        {
            Console.WriteLine("Превращаем лёд в жидкость");
            water.State = new LiquidState();
        }
    }

    class LiquidState : IWaterState
    {
        public void Froze(Water water)
        {
            Console.WriteLine("Превращаем жидкость в лёд");
            water.State = new SolidState();
        }

        public void Heat(Water water)
        {
            Console.WriteLine("Превращаем жидкость в пар");
            water.State = new GasState();
        }
    }

    class GasState : IWaterState
    {
        public void Froze(Water water)
        {
            Console.WriteLine("Превращаем пар в жидкость");
            water.State = new LiquidState();
        }

        public void Heat(Water water)
        {
            Console.WriteLine("Повышаем температуру пара");
        }
    }

    class Water
    {
        public IWaterState State { get; set; }
        public Water(IWaterState state)
        {
            State = state;
        }

        public void Heat()
        {
            State.Heat(this);
        }

        public void Froze()
        {
            State.Froze(this);
        }
    }
}
