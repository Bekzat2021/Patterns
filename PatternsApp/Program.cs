using System;
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

            //IFigure circle = new Circle(30);
            //var clonedCircle = circle.Clone();
            //circle.GetInfo();
            //clonedCircle.GetInfo();

            IUser admin = new Admin("Admin01");
            var admin02 = admin.Clone();
            admin.Info();
            admin02.Info();


            IUser player = new Player("Ken0235");
            IUser player5 = player.Clone();
            player.Info();
            player5.Info();
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
        public Circle(int r)
        {
            radius = r;
        }
        public IFigure Clone()
        {
            return new Circle(this.radius);
        }

        public void GetInfo()
        {
            Console.WriteLine($"Круг радиусом {radius}");
        }
    }

    interface IUser
    {
        IUser Clone();
        void Info();
    }

    class Admin : IUser
    {
        public string Name { get; set; }
        public Admin(string name)
        {
            Name = name;
        }

        public IUser Clone()
        {
            return new Admin(Name);
        }

        public void Info()
        {
            Console.WriteLine($"My name is {Name}");
        }
    }

    class Player : IUser
    {
        public string Nickname { get; set; }
        public Player(string nickname)
        {
            Nickname = nickname;
        }
        public IUser Clone()
        {
            return new Player(Nickname);
        }

        public void Info()
        {
            Console.WriteLine($"My Nickname is {Nickname}");
        }
    }
}
