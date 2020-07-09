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
            Jet jet = new Jet();
            Helicopter helicopter = new Helicopter();

            jet.Fly();
            helicopter.Fly();
        }
    }

    abstract class Aircraft
    {
        public abstract void Fly();
    }

    abstract class AircraftWithEngine : Aircraft
    {
        sealed public override void Fly()
        {
            PreflightCheck();
            Takeoff();
            Flight();
            Landing();
        }

        public abstract void PreflightCheck();
        public abstract void Takeoff();
        public virtual void Flight()
        {
            Console.WriteLine("Aircraft with engine fly");
        }
        public abstract void Landing();
    }

    class Jet : AircraftWithEngine
    {
        public override void PreflightCheck()
        {
            Console.WriteLine("Jet's pre flight check");
        }

        public override void Takeoff()
        {
            Console.WriteLine("Jet's takeoff on long runway");
        }

        public override void Landing()
        {
            Console.WriteLine("Jet's landing on long runway");
        }
    }

    class Helicopter : AircraftWithEngine
    {
        public override void PreflightCheck()
        {
            Console.WriteLine("Helicopter's pre flight check");
        }

        public override void Takeoff()
        {
            Console.WriteLine("Helicopter's takeoff vertical");
        }

        public override void Flight()
        {
            Console.WriteLine("Helicopter flight sideways");
        }

        public override void Landing()
        {
            Console.WriteLine("Helicopter's vertical landing");
        }
    }
}
