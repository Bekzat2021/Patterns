using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;


namespace PatternsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //IFigure figure = new Rectangle(30, 40);
            //IFigure clonedFigure = figure.Clone();
            //figure.GetInfo();
            //clonedFigure.GetInfo();

            Circle circle = new Circle(30, 50, 60);
            var clonedCircle = circle.Clone() as Circle;
            circle.Point.X = 100;
            circle.GetInfo();
            clonedCircle.GetInfo();
        }
    }

    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Rectangle : IFigure
    {
        int width;
        int height;

        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }
        public IFigure Clone()
        {
            return new Rectangle(this.width, this.height);
        }

        public void GetInfo()
        {
            Console.WriteLine($"Прямоугольник длиной {height} и шириной {width}");
        }
    }

    class Circle : IFigure
    {
        int radius;
        public Point Point { get; set; }
        public Circle(int r, int x, int y)
        {
            radius = r;
            this.Point = new Point { X = x, Y = y };
        }
        public IFigure Clone()
        {
            return this.MemberwiseClone() as IFigure;
        }

        public object DeepCopy()
        {
            object figure = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                figure = binFormatter.Deserialize(tempStream);
            }
            return figure;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Круг радиусом {radius} и центром в точке ({Point.X}, {Point.Y})");
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
