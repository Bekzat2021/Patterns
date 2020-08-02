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
            TextEditor vsCode = new TextEditor();
            Compiler csc = new Compiler();
            CLR clr = new CLR();

            VisualStudioFacade VS2019 = new VisualStudioFacade(vsCode, csc, clr);

            Programmer bob = new Programmer();
            bob.StartApp(VS2019);

            Console.WriteLine(" * * * ");
            
            bob.StopApp(VS2019);
        }
    }

    class TextEditor
    {
        public void Write()
        {
            Console.WriteLine("Writing code");
        }

        public void Save()
        {
            Console.WriteLine("Save code");
        }
    }

    class Compiler
    {
        public void Compile()
        {
            Console.WriteLine("Compiling code");
        }
    }

    class CLR
    {
        public void Start()
        {
            Console.WriteLine("Starting application");
        }

        public void Stop()
        {
            Console.WriteLine("Shutdown application");
        }
    }

    class VisualStudioFacade
    {
        private TextEditor textEditor;
        private Compiler compiler;
        private CLR clr;
        public VisualStudioFacade(TextEditor te, Compiler comp, CLR cl)
        {
            textEditor = te;
            compiler = comp;
            clr = cl;
        }

        public void RunApp()
        {
            textEditor.Write();
            textEditor.Save();
            compiler.Compile();
            clr.Start();
        }

        public void ShutdownApp()
        {
            clr.Stop();
        }
    }

    class Programmer
    {
        public void StartApp(VisualStudioFacade visualStudioFacade)
        {
            visualStudioFacade.RunApp();
        }

        public void StopApp(VisualStudioFacade visualStudioFacade)
        {
            visualStudioFacade.ShutdownApp();
        }
    }
}
