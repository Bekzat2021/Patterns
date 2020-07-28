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
            ManagerMediator mediator = new ManagerMediator();
            Colleague programmer = new ProgrammerColleague(mediator);
            Colleague tester = new TesterColleague(mediator);
            Colleague customer = new CustomerColleague(mediator);

            mediator.Customer = customer;
            mediator.Programmer = programmer;
            mediator.Tester = tester;

            customer.Send("Есть заказ, надо сделать программу");
            programmer.Send("Программа готова, надо протестировать");
            tester.Send("Программа протестирована и готова к продаже");
        }
    }

    public abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }

    public abstract class Colleague
    {
        Mediator mediator;
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }

        public abstract void Notify(string message);
    }

    public class CustomerColleague : Colleague
    {
        public CustomerColleague(Mediator mediator) : base(mediator) { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение заказчику: " + message);
        }
    }

    public class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(Mediator mediator) : base(mediator) { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение программисту: " + message);
        }
    }

    public class TesterColleague : Colleague
    {
        public TesterColleague(Mediator mediator) : base(mediator) { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение тестеру: " + message);
        }
    }

    class ManagerMediator : Mediator
    {
        public Colleague Programmer { get; set; }
        public Colleague Tester { get; set; }
        public Colleague Customer { get; set; }
        public override void Send(string message, Colleague colleague)
        {
            if (colleague == Customer)
                Programmer.Notify(message);
            else if (colleague == Programmer)
                Tester.Notify(message);
            else if (colleague == Tester)
                Customer.Notify(message);
        }
    }
}
