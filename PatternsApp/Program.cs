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
            //Receiver receiver = new Receiver(false, false, true);

            //PaymentHandler bankHandler = new BankPaymentHandler();
            //PaymentHandler moneyHandler = new MoneyPaymentHandler();
            //PaymentHandler payPalHandler = new PayPalPaymentHandler();

            //bankHandler.Successor = moneyHandler;
            //moneyHandler.Successor = payPalHandler;

            //bankHandler.Handle(receiver);

            Client client = new Client(false, false, true);
            DepartmentsHandler salesHandler = new SalesDepartment();
            DepartmentsHandler itHandler = new ItDepartment();
            DepartmentsHandler marketingHandler = new MarketingDepartment();

            salesHandler.Successor = itHandler;
            itHandler.Successor = marketingHandler;

            salesHandler.Handler(client);


            int num = 1;
            for (int i = 0; i < 100; i++)
            {
                switch (num)
                {
                    case 1:
                        Console.Write("\\---\r");
                        num = 2;
                        break;
                    case 2:
                        Console.Write("-|--\r");
                        num = 3;
                        break;
                    case 3:
                        Console.Write("--|-\r");
                        num = 4;
                        break;
                    case 4:
                        Console.Write("---/\r");
                        num = 1;
                        break;
                }
                Thread.Sleep(300);
            }
        }
    }

    class Client
    {
        public bool sales { get; set; }
        public bool it { get; set; }
        public bool marketing { get; set; }
        public Client(bool s, bool i, bool m)
        {
            sales = s;
            it = i;
            marketing = m;
        }
    }

    abstract class DepartmentsHandler
    {
        public DepartmentsHandler Successor { get; set; }
        public abstract void Handler(Client client);
    }

    class SalesDepartment : DepartmentsHandler
    {
        public override void Handler(Client client)
        {
            if (client.sales)
                Console.WriteLine("Client served in sales department");
            else if (Successor != null)
                Successor.Handler(client);
        }
    }

    class ItDepartment : DepartmentsHandler
    {
        public override void Handler(Client client)
        {
            if (client.it)
                Console.WriteLine("Client served in sales department");
            else if (Successor != null)
                Successor.Handler(client);
        }
    }

    class MarketingDepartment : DepartmentsHandler
    {
        public override void Handler(Client client)
        {
            if (client.marketing)
                Console.WriteLine("Client served in sales department");
            else if (Successor != null)
                Successor.Handler(client);
        }
    }

    //class Receiver
    //{
    //    public bool BankTransfer { get; set; }
    //    public bool MoneyTransfer { get; set; }
    //    public bool PayPalTransfer { get; set; }
    //    public Receiver(bool bt, bool mt, bool ppt)
    //    {
    //        BankTransfer = bt;
    //        MoneyTransfer = mt;
    //        PayPalTransfer = ppt;
    //    }
    //}

    //abstract class PaymentHandler
    //{
    //    public PaymentHandler Successor { get; set; }
    //    public abstract void Handle(Receiver receiver);
    //}

    //class BankPaymentHandler : PaymentHandler
    //{
    //    public override void Handle(Receiver receiver)
    //    {
    //        if (receiver.BankTransfer)
    //            Console.WriteLine("Выполняем банковский перевод");
    //        else if (Successor != null) 
    //            Successor.Handle(receiver);
    //    }
    //}

    //class MoneyPaymentHandler : PaymentHandler
    //{
    //    public override void Handle(Receiver receiver)
    //    {
    //        if (receiver.MoneyTransfer)
    //            Console.WriteLine("Выполняем перевод через системы денежных переводов");
    //        else if (Successor != null)
    //            Successor.Handle(receiver);
    //    }
    //}

    //class PayPalPaymentHandler : PaymentHandler
    //{
    //    public override void Handle(Receiver receiver)
    //    {
    //        if (receiver.PayPalTransfer)
    //            Console.WriteLine("Выполняем перевод через PayPal");
    //        else if (Successor != null)
    //            Successor.Handle(receiver);
    //    }
    //}
}
