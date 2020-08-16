using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
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
            Cook smith = new Cook("Smith");
            smith.MakeDinner(new PotatoMeal());
            smith.MakeDinner(new SaladMeal());
        }
    }

    interface IMeal
    {
        void Make();
    }

    class Cook
    {
        public string Name { get; set; }
        public Cook(string name)
        {
            Name = name;
        }

        public void MakeDinner(IMeal meal)
        {
            meal.Make();
        }
    }

    class PotatoMeal : IMeal
    {
        public void Make()
        {
            Console.WriteLine("Чистим и моем картошку");
            Console.WriteLine("Ставим почищенную картошку на огонь");
            Console.WriteLine("Варим около 30 минут");
            Console.WriteLine("Сливаем остатки воды, разминаем варенный картофель в пюре");
            Console.WriteLine("Посыпаем пюре специями и зеленью");
            Console.WriteLine("Картофельное пюре готово");
        }
    }

    class SaladMeal : IMeal
    {
        void IMeal.Make()
        {
            Console.WriteLine("Моем помидоры и огурцы");
            Console.WriteLine("Нарезаем помидоры и огурцы");
            Console.WriteLine("Поспаем зеленью, солью и специями");
            Console.WriteLine("Поливаем подсолнечным маслом");
            Console.WriteLine("Салат готов");
        }
    }
}
