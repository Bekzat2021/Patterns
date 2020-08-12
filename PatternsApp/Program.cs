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
            Programmer freelancer = new FreelanceProgrammer(new CPPLanguage());
            freelancer.Work();
            freelancer.EarnMoney();

            freelancer.Language = new CSharpLanguage();
            freelancer.Work();
            freelancer.EarnMoney();

            Console.WriteLine();
            
            CorporateProgrammer corporateProgrammer = new CorporateProgrammer(new CSharpLanguage());
            corporateProgrammer.Work();
            corporateProgrammer.EarnMoney();
        }
    }

    interface ILanguage
    {
        void Build();
        void Execute();
    }

    class CPPLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("Using the C ++ compiler, we compile the program into binary code");
        }

        public void Execute()
        {
            Console.WriteLine("Run the executable file of the program");
        }
    }

    class CSharpLanguage : ILanguage
    {
        void ILanguage.Build()
        {
            Console.WriteLine("Using the Roslyn compiler, we compile the source code into an exe file");
        }

        void ILanguage.Execute()
        {
            Console.WriteLine("JIT compiles a binary program /nCLR executes compiled binary");
        }
    }

    abstract class Programmer
    {
        public ILanguage Language { get; set; }
        public Programmer(ILanguage lang)
        {
            Language = lang;
        }

        public virtual void Work()
        {
            Language.Build();
            Language.Execute();
        }

        public abstract void EarnMoney();
    }

    class FreelanceProgrammer : Programmer
    {
        public FreelanceProgrammer(ILanguage lang) : base(lang)
        {

        }
        public override void EarnMoney()
        {
            Console.WriteLine("We receive payment for the completed order");
        }
    }

    class CorporateProgrammer : Programmer
    {
        public CorporateProgrammer(ILanguage lang) : base(lang)
        {

        }
        public override void EarnMoney()
        {
            Console.WriteLine("We receive a salary at the end of the month");
        }
    }
}
