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
            Context context = new Context();
            context.SetValue("x", 5);
            context.SetValue("y", 13);

            IExpression expression = new AddExpression(
                    new NumberExpression("x"), new NumberExpression("y"));
            
            int result = expression.Interpret(context);
            Console.WriteLine(result);

        }
    }

    class Context
    {
        Dictionary<string, int> variables;
        public Context()
        {
            variables = new Dictionary<string, int>();
        }

        public int GetValue(string name)
        {
            return variables[name];
        }

        public void SetValue(string name, int number)
        {
            if (variables.ContainsKey(name))
                variables[name] = number;
            else
                variables.Add(name, number);
        }
    }

    interface IExpression
    {
        int Interpret(Context context);
    }

    class NumberExpression : IExpression
    {
        string name;
        public NumberExpression(string name)
        {
            this.name = name;
        }
        public int Interpret(Context context)
        {
            return context.GetValue(name);
        }
    }

    class AddExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;
        public AddExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }
        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) + rightExpression.Interpret(context);
        }
    }
}
