using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RealCar chevrolet = new RealCar(new Red_V8());

            chevrolet.LaunchEngine();
            chevrolet.ShowPaint();
        }
    }

    class RealCar
    {
        private Engine engine;
        private Paint paint;
        public RealCar(CreateCar carParams)
        {
            engine = carParams.MakeEngine();
            paint = carParams.PaintCar();
        }

        public void LaunchEngine()
        {
            engine.Work();
        }

        public void ShowPaint()
        {
            paint.ShowColor();
        }
    }

    class Black_v6Turbo : CreateCar
    {
        public override Engine MakeEngine()
        {
            return new V6TurboEngine();
        }

        public override Paint PaintCar()
        {
            return new BlackCar();
        }
    }

    class Red_V8 : CreateCar
    {
        public override Engine MakeEngine()
        {
            return new V8Engine();
        }

        public override Paint PaintCar()
        {
            return new RedCar();
        }
    }

    abstract class CreateCar
    {
        public abstract Engine MakeEngine();
        public abstract Paint PaintCar();
    }
    
    abstract class Engine
    {
        public abstract void Work();
    };

    abstract class Paint
    {
        public abstract void ShowColor();
    };

    class RedCar : Paint
    {
        public override void ShowColor()
        {
            Console.WriteLine("Red color");
        }
    }

    class BlackCar : Paint
    {
        public override void ShowColor()
        {
            Console.WriteLine("Black color");
        }
    }

    class V8Engine : Engine
    {
        public override void Work()
        {
            Console.WriteLine("V8 engine work");
        }
    }

    class V6TurboEngine : Engine
    {
        public override void Work()
        {
            Console.WriteLine("V6 turbo engine work");
        }
    }
}
