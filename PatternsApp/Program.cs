using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatternsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Kamenshik kamenshik = new Kamenshik();
            Santehik santehik = new Santehik();
            Electrik electrik = new Electrik();

            MacroCommand commands = new MacroCommand(new List<ICommand>{
                new KamnshikCommand(kamenshik),
                new SantehnikCommand(santehik),
                new ElectrikCommand(electrik)
            });

            Brigadir brigadir = new Brigadir(commands);
            brigadir.Execute();
            brigadir.Undo();
        }
    }

    interface ICommand
    {
        void Execute();
        void Undo();
    }

    class MacroCommand : ICommand
    {
        private List<ICommand> commands;
        public MacroCommand(List<ICommand> com)
        {
            commands = com;
        }
        public void Execute()
        {
            foreach (ICommand command in commands)
            {
                command.Execute();
            }
        }

        public void Undo()
        {
            foreach (ICommand command in commands)
            {
                command.Undo();
            }
        }
    }

    class Kamenshik 
    {
        public void StartWork()
        {
            Console.WriteLine("Каменьщик начал класт камень");
        }

        public void StopWork()
        {
            Console.WriteLine("Каменьщик закончил класть камень");
        }
    }

    class KamnshikCommand : ICommand
    {
        private Kamenshik kamenshik;
        public KamnshikCommand(Kamenshik k)
        {
            kamenshik = k;
        }
        public void Execute()
        {
            kamenshik.StartWork();
        }

        public void Undo()
        {
            kamenshik.StopWork();
        }
    }

    class Santehik 
    {
        public void StartWork()
        {
            Console.WriteLine("Сантехник начал проводить трубы");
        }

        public void StopWork()
        {
            Console.WriteLine("Сантехник закончил проводить трубы");
        }
    }

    class SantehnikCommand : ICommand
    {
        Santehik santehik;
        public SantehnikCommand(Santehik s)
        {
            santehik = s;
        }
        public void Execute()
        {
            santehik.StartWork();
        }

        public void Undo()
        {
            santehik.StopWork();
        }
    }

    class Electrik 
    {
        public void StartWork()
        {
            Console.WriteLine("Электрик начал ложить провода");
        }

        public void StopWork()
        {
            Console.WriteLine("Электрик закончил ложить провода");
        }
    }

    class ElectrikCommand : ICommand
    {
        private Electrik electric;
        public ElectrikCommand(Electrik e)
        {
            electric = e;
        }
        public void Execute()
        {
            electric.StartWork();
        }

        public void Undo()
        {
            electric.StopWork();
        }
    }

    class Brigadir : ICommand
    {
        private ICommand command;
        public Brigadir(ICommand c)
        {
            command = c;
        }

        public void Execute()
        {
            command.Execute();
        }

        public void Undo()
        {
            command.Undo();
        }
    }
}
