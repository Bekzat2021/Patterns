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

            context.SetVariable("x", 9);
            context.SetVariable("y", 7);

            AddExpression sum = new AddExpression(new NumberExpression("x"), new NumberExpression("y"));
                
            int result = sum.Interpret(context);

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

        public int GetVariable(string name)
        {
            return variables[name];
        }

        public void SetVariable(string name, int value)
        {
            if (variables.ContainsKey(name))
                variables[name] = value;
            else
                variables.Add(name, value);
        }
    }

    interface IExpression
    {
        int Interpret(Context context);
    }

    class NumberExpression : IExpression
    {
        string name;
        public NumberExpression(string n)
        {
            name = n;
        }

        public int Interpret(Context context)
        {
            return context.GetVariable(name);
        }
    }

    class AddExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;

        public AddExpression(IExpression leftEx, IExpression rightEx)
        {
            leftExpression = leftEx;
            rightExpression = rightEx;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) + rightExpression.Interpret(context);
        }
    }

    class SubtractExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;
        public SubtractExpression(IExpression leftEx, IExpression rightEx)
        {
            leftExpression = leftEx;
            rightExpression = rightEx;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) - rightExpression.Interpret(context);
        }
    }
}
