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
            Hero hero = new Hero();
            hero.Shoot();
            hero.Shoot();

            GameHistory history = new GameHistory();
            history.Log.Add("Первое сохранение", hero.Save());
            hero.Shoot();
            hero.Shoot();
            history.Log.Add("Второе сохранение", hero.Save());

            history.ShowSavedGames();

            Console.WriteLine("***");

            hero.Restore(history.Log["Первое сохранение"]);

            hero.Shoot();
        }
    }

    class Hero
    {
        private int bullets = 10;
        private int health = 100;

        public void Shoot()
        {
            if (bullets > 0)
            {
                bullets--;
                Console.WriteLine($"Стреляем. Осталось {bullets} патронов");
            }
            else
            {
                Console.WriteLine("Патронов нет");
            }
        }

        public MementoHero Save()
        {
            Console.WriteLine($"Сохраняемся уровень здоровья: {health} патронов: {bullets}");
            return new MementoHero(bullets, health);
        }

        public void Restore(MementoHero memento)
        {
            this.bullets = memento.Bullets;
            this.health = memento.Health;
        }
    }

    class MementoHero
    {
        public int Bullets { get; set; }
        public int Health { get; set; }
        public MementoHero(int bullets, int health)
        {
            Bullets = bullets;
            Health = health;
        }
    }

    class GameHistory
    {
        public Dictionary<string, MementoHero> Log;
        public GameHistory()
        {
            Log = new Dictionary<string, MementoHero>();
        }

        public void ShowSavedGames()
        {
            Console.WriteLine("*** Список всех сохранении ***");
            foreach (var item in Log)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Bullets} - {item.Value.Health}");
            }
        }
    }
}
